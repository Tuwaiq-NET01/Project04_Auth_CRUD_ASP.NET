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
            return View();
        }

        public IActionResult Dotnet()
        {
            var course = _db.Courses.Where<CoursesModel>(course => course.subject == "Dot Net").First();
            course.Files = _db.Files.Where(file => file.course_id == course.id).ToList();
            ViewData["Dotnet"] = course;
            return View(course);
          
        }

        public IActionResult React()
        {
            var course = _db.Courses.Where<CoursesModel>(course => course.subject == "React").First();
            course.Files = _db.Files.Where(file => file.course_id == course.id).ToList();
            ViewData["React"] = course;
            return View(course);
        }
        public IActionResult Design()
        {
            var course = _db.Courses.Where<CoursesModel>(course => course.subject == "Design patterns").First();
            course.Files = _db.Files.Where(file => file.course_id == course.id).ToList();
            ViewData["Design"] = course;
            return View(course);
        }
        public IActionResult Unit()
        {
            var course = _db.Courses.Where<CoursesModel>(course => course.subject == "Unit testing").First();
            course.Files = _db.Files.Where(file => file.course_id == course.id).ToList();
            ViewData["Unit"] = course;
            return View(course);
        }
    }
}
