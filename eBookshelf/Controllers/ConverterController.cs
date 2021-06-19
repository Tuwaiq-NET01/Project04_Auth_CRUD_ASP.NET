using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
//using pdfcrowd;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eBookshelf.Controllers
{
    public class ConverterController : Controller
    {
        private IHostingEnvironment Environment;
        public ConverterController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }


        //https://medium.com/capital-one-tech/caches-are-key-to-scaling-da2749adc6c9
        // GET: /<controller>/

        //public async Task<IActionResult> Index(string url)
        //{
        //    if (url == null) return NotFound();

        //    string filePath = Environment.WebRootPath + "/Temp/file.pdf";

        //    try
        //    {
        //        // create the API client instance
        //        pdfcrowd.HtmlToPdfClient client =
        //            new pdfcrowd.HtmlToPdfClient("ThamerMashni", "83f48c790e1c1f883a9641be695a191c");

        //        if (System.IO.File.Exists(filePath))
        //        {
        //            System.IO.File.Delete(filePath);
        //        }

        //        FileStream fileStream = System.IO.File.Create(filePath);
        //        MemoryStream ms = new MemoryStream();
        //        await using(fileStream)
        //        {
        //            try
        //            {
        //                client.convertUrlToStream(url, fileStream);
        //                //fileStream.Close();
        //                fileStream.CopyTo(ms);
        //            }
        //            catch (Error)
        //            {
        //                fileStream.Close();
        //                System.IO.File.Delete(filePath);
        //                throw;
        //            }
        //        }
 
        //        //var document = new Aspose.Pdf.Document();
        //        //var output = Environment.WebRootPath + "/Temp/output.epub";
        //        //document.Save(output, Aspose.Pdf.SaveFormat.Epub);

        //        //var fileName = Guid.NewGuid().ToString() + ".pdf";
        //        //return File("/Temp/file.pdf", "application/pdf", fileName);
        //        //FileStream fRead = new FileStream(@"M:\Documents\Textfile.txt",
        //        //       FileMode.Open, FileAccess.Read, FileShare.Read);

        //        //using (FileStream fs = fileStream.BeginRead())

        //    }
        //    catch (pdfcrowd.Error why)
        //    {
        //        // report the error
        //        System.Console.Error.WriteLine("Pdfcrowd Error: " + why);

        //        // rethrow or handle the exception
        //        throw;
        //    }
        //    //{

        //    //Document pdfDocument = new Document(Environment.WebRootPath + "/Temp/file.pdf");

        //    EpubSaveOptions options = new EpubSaveOptions();
        //    options.ContentRecognitionMode = EpubSaveOptions.RecognitionMode.Flow;
        //    using (var pdfDocument = new Aspose.Pdf.Document(filePath))
        //    {
        //        Console.WriteLine($"Pages {pdfDocument.Pages.Count}");
        //        pdfDocument.Save(Environment.WebRootPath + "/Temp/PDFToEPUB_out.epub", options);

        //    }

        //    //pdfDocument.Save(Environment.WebRootPath + "/Temp/PDFToEPUB_out.epub", options);


        //    //await using (FileStream epubStream = new FileStream(Environment.WebRootPath + "/Temp/PDFToEPUB_out.epub", FileMode.Create))
        //    //{
        //    //    //// Create Resolution object
        //    //    //Resolution resolution = new Resolution(300);
        //    //    //// Create Jpeg device with specified attributes
        //    //    //// Width, Height, Resolution
        //    //    //JpegDevice JpegDevice = new JpegDevice(500, 700, resolution);

        //    //    //// Convert a particular page and save the image to stream
        //    //    //JpegDevice.Process(pdfDocument.Pages[1], epubStream);
        //    //    // Close stream
        //    //    epubStream.Close();
        //    //}

        //    //}
        //    var fileName = Guid.NewGuid().ToString() + ".epub";
        //    return File("/Temp/PDFToEPUB_out.epub", "application/epub+zip", fileName);
            
        //}

        public async Task<ActionResult> convertPdfToEpub()
        {
            ////pdf to epub
            string filePath = Environment.WebRootPath + "/Temp/file.pdf";

            //Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(filePath);

            EpubSaveOptions options = new EpubSaveOptions();
            options.ContentRecognitionMode = EpubSaveOptions.RecognitionMode.Flow;
            //pdfDocument.Pages.Add();
            ////MemoryStream ms = new MemoryStream();
            //pdfDocument.Save(Environment.WebRootPath + "/Temp/PDFToEPUB_out.pdf");
            ////pdfDocument.Save(ms,options);

            //var pdfDocument = new Aspose.Pdf.Document(filePath);
            
            //Console.WriteLine($"Pages {pdfDocument.Pages.Count}");
            //pdfDocument.Save(Environment.WebRootPath + "/Temp/PDFToEPUB_out.pdf");
            //MemoryStream ms = new MemoryStream();

            Document doc = new Document(new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite));
            Console.WriteLine($"Pages {doc.Pages.Count}");
            using (var streamOut = new MemoryStream())
            {
                doc.Save(streamOut, new PdfSaveOptions());
                return File(streamOut, "application/pdf","File.pdf");
            }
            //var ls = pdfDocument.Convert(ms, new EpubLoadOptions(),"", options);


            //// Initialize document object
            //Document document = new Document();
            //// Add page
            //Page page = document.Pages.Add();
            //// Add text to new page
            //page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Hello World!"));
            //// Save updated PDF
            //document.Save(Environment.WebRootPath + "/HelloWorld_out.pdf");

            var fileName = Guid.NewGuid().ToString() + ".pdf";
            //return File(Environment.WebRootPath + "/HelloWorld_out.pdf", "application /pdf", fileName);
            //return File(filePath, "application/epub+zip", fileName);
        }
    }
}
