using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalProject.Data;
using finalProject.Models;


namespace finalProject.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CoursesController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var courses = _db.Courses.ToList();
            ViewData["courses"] = courses;
            return View();
        }
    }
}
