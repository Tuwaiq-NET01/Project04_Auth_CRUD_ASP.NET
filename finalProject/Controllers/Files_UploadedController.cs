using finalProject.Data;
using finalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace finalProject.Controllers
{
    public class Files_UploadedController : Controller
    {
        private readonly ApplicationDbContext _db;

        public Files_UploadedController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Index(IFormFile postedFile)
        {

            // List<string> uploadedFiles = new List<string>();
            // foreach (IFormFile postedFile in postedFiles)
            // {
            if (postedFile.Length > 0)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                string Dir = Environment.CurrentDirectory + "/UploadedFiles";
                if (!Directory.Exists(Dir))
                {
                    Directory.CreateDirectory(Dir);
                }
                string path = Path.Combine(Dir, fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
            }
            return View();
        }
    }
}
