using finalProject.Data;
using finalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            // all the course
            return View();
        }
    

       [HttpPost]
        public IActionResult Delete(int? ID)
        {
            var file = _db.Files.FirstOrDefault(findFile  => findFile.id == ID);
            _db.Files.Remove(file);
            _db.SaveChanges();

           /* var course = _db.Courses.ToList();
            if (course.subject == "Dot Net")
            {
                return RedirectToAction("Dotnet");

            }else if (course.subject == "React")
            {
                return RedirectToAction("React");

            }
            else if (course.subject == "Design")
            {
                return RedirectToAction("Design");

            }
            else */
                return RedirectToAction("Index");
        } 
    }
}
