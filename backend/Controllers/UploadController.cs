using backend.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

namespace backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly string _tempFolder;

        public UploadController()
        {
            _tempFolder = Directory.GetCurrentDirectory() + "\\temp";
            if (!Directory.Exists(_tempFolder))
                Directory.CreateDirectory(_tempFolder);
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                var file = Request.Form.Files[0];
                var pathToSave = _tempFolder;
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(_tempFolder, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        stream.Close();
                    }
                    return Ok(new { Status = "Uploaded", FileName = fileName });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
                var files = new List<string>();
                string[] fileEntries = Directory.GetFiles(_tempFolder);

                foreach(var file in fileEntries)
                {
                    files.Add(file.Split('\\')[^1]);
                }

                if(files.Count > 0)
                {
                    return Ok(new { files });
                }
                else
                {
                    return NotFound(new Response { Status = "Error", Message = "No files found on the server!" });
                }
        }

        [HttpGet("{FileName}")]
        public IActionResult Get(string FileName)
        {
            string filePath = Path.Combine(_tempFolder, FileName);
            if(System.IO.File.Exists(filePath))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/force-download", FileName);
            }
            return NotFound(new Response { Status = "Error", Message = $"{FileName} was not found on the server!" });
        }

        [HttpGet("[action]/{FileName}")]
        public IActionResult Find(string FileName)
        {
            string[] fileEntries = Directory.GetFiles(_tempFolder);

            foreach (var filePath in fileEntries)
            {
                if (filePath.Contains(FileName))
                    return Ok(new { Status = "Found", Message = $"{FileName} was found on the server!", FileName = FileName, Path = filePath });
            }

            return NotFound(new Response { Status = "Error", Message = $"{FileName} was not found on the server!" });
        }

        [HttpDelete("{FileName}")]
        public IActionResult Delete(string FileName)
        {
            string[] fileEntries = Directory.GetFiles(_tempFolder);

            foreach (var filePath in fileEntries)
            {
                if (filePath.Contains(FileName))
                {
                    System.IO.File.Delete(filePath);
                    return Ok(new { Status = "Deleted", FileName = FileName, Message = $"{FileName} was deleted from the server!" });
                }
            }

            return NotFound(new Response { Status = "Error", Message = $"{FileName} was not found on the server!" });
        }
    }
}
