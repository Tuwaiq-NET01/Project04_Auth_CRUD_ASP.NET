using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace backend.Modules
{
    public sealed class BitChunk
    {
        public string InputFileName { get; set; }
        public long InputFileSize { get; set; }
        public long ChunkSize { get; set; }
        public List<string> ChunksMetaData { get; set; }
        List<string> ChunkFiles { get; set; }
        public string RefFile { get; set; }
        public string OriginalFileName { get; set; }
        public int OriginalFileSize { get; set; }
        public int OriginalChunkSize { get; set; }
        public int ChunksCount { get; set; }
        public string ReassembledFileName { get; set; }

        public string Folder { get; set; }

        public BitChunk()
        {
            ChunksMetaData = new List<string>();
            ChunkFiles = new List<string>();
            Directory.CreateDirectory("./servers/A");
            Directory.CreateDirectory("./servers/B");
            Directory.CreateDirectory("./servers/C");
            Directory.CreateDirectory("./servers/D");
        }

        public void SetFile(string fileName)
        {
            InputFileName = fileName;
        }

        public void Shred()
        {
            if (InputFileName != null)
            {
                using (BinaryReader reader = new BinaryReader(File.Open(InputFileName, FileMode.Open)))
                {
                    FileInfo fi = new FileInfo(InputFileName);
                    long fileSize = fi.Length;
                    InputFileSize = fileSize;
                    int numOfChunks = GetNumberOfChunks(fileSize);
                    long chunkSize = fileSize / numOfChunks;
                    ChunkSize = chunkSize;
                    byte[] chunkData;
                    string chunkHashName = "";

                    for (int i = 0; i < numOfChunks; i++)
                    {
                        if (File.Exists(InputFileName))
                        {
                            chunkData = reader.ReadBytes((int)chunkSize);
                            chunkHashName = GetRandomServer() + GetHashFileName(chunkData);
                            ChunksMetaData.Add(chunkHashName);
                            using (BinaryWriter writer = new BinaryWriter(File.Open(chunkHashName + ".cnk", FileMode.Create)))
                            {
                                foreach (var byt in chunkData)
                                {
                                    writer.Write(byt);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void GenerateRef()
        {
            // Generate ref file
            string refName = InputFileName.Split('.')[0] + ".ref";
            RefFile = refName;
            using (BinaryWriter writer = new BinaryWriter(File.Open(refName, FileMode.Create)))
            {
                writer.Write(InputFileName);
                writer.Write((int)InputFileSize);
                writer.Write((int)ChunkSize);
                writer.Write(ChunksMetaData.Count);
                foreach (var chunkMetaData in ChunksMetaData)
                {
                    writer.Write(chunkMetaData);
                }
            }
        }

        public void EncryptRef(string file, string encryptionKey)
        {
            // Encrypt ref file with AES specification
            string newRefFile = file + ".aes";
            FileEncrypt(file, encryptionKey);
            File.Delete(file);
            RefFile = newRefFile;
        }

        public void DecryptRef(string file, string password)
        {
            string newRefFile = file.Split('.')[0] + ".ref";
            FileDecrypt(file, newRefFile, password);
            File.Delete(file);
            RefFile = newRefFile;
        }

        public void ParseRef(string fileName)
        {
            // Read ref file and extract meta data
            string temp;
            using (BinaryReader refReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                OriginalFileName = refReader.ReadString().Split("\\")[^1];
                OriginalFileSize = refReader.ReadInt32();
                OriginalChunkSize = refReader.ReadInt32();
                ChunksCount = refReader.ReadInt32();
                for (int i = 0; i < ChunksCount; i++)
                {
                    temp = refReader.ReadString();
                    ChunkFiles.Add(temp);
                }
            }
        }

        public void ReassembleFile(string password)
        {
            // Assemble the file using the meta data and right access to chunks
            string ressebledFileName = "./temp/bitchunk-" + OriginalFileName;
            ReassembledFileName = ressebledFileName;
            using (BinaryWriter writer = new BinaryWriter(File.Open(ressebledFileName, FileMode.Create)))
            {
                byte[] bytes;
                string fileToDecrypt;
                string decryptedFile;
                for (int i = 0; i < ChunksCount; i++)
                {
                    // Decrypt all chunks provided encryption key (password)
                    fileToDecrypt = ChunkFiles[i] + ".cnk.aes";
                    decryptedFile = ChunkFiles[i] + ".cnk";
                    FileDecrypt(fileToDecrypt, decryptedFile, password);
                    File.Delete(fileToDecrypt);
                    using (BinaryReader chunkReader = new BinaryReader(File.Open(decryptedFile, FileMode.Open)))
                    {
                        bytes = chunkReader.ReadBytes(OriginalChunkSize);
                        foreach (var byt in bytes)
                        {
                            writer.Write(byt);
                        }
                    }
                }
            }
        }

        public void EncryptChunks(string encryptionKey)
        {
            // Encrypt all chunks with AES specification
            string fileToEncrypt;
            foreach (var chunkMetaData in ChunksMetaData)
            {
                fileToEncrypt = chunkMetaData + ".cnk";
                FileEncrypt(fileToEncrypt, encryptionKey);
                File.Delete(fileToEncrypt);
            }
        }

        private byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        private void FileEncrypt(string inputFile, string password)
        {
            byte[] salt = GenerateRandomSalt();

            FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            //Set Rijndael symmetric encryption algorithm
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CFB;

            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    cs.Write(buffer, 0, read);
                }

                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }
        }

        private void FileDecrypt(string inputFile, string outputFile, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                string erro = ex_CryptographicException.Message;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
        }

        private string GetHashFileName(byte[] chunkData)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash((chunkData));
                var sb = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private string GetRandomServer()
        {
            Random rand = new Random();
            int randomServer = rand.Next(1, 5);
            switch (randomServer)
            {
                case 1:
                    return "./servers/A/";
                case 2:
                    return "./servers/B/";
                case 3:
                    return "./servers/C/";
                case 4:
                    return "./servers/D/";
                default:
                    return "./servers/A/";
            }
        }

        public int GetNumberOfChunks(long fileSize)
        {
            int minimumChunks = 4;
            while (fileSize % minimumChunks != 0)
                minimumChunks++;
            return minimumChunks;
        }

    }
}
