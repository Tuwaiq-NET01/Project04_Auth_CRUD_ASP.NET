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

        // GET - /courses/details/id

        public IActionResult Details (int? id)
        {
            var course = _db.Courses.ToList().Find(c => c.id == id);
            ViewData["course"] = course;
            return View();
        }

        //GET: /courses/create
        public IActionResult Create()
        {
            return View();
        }

        //POST: /courses/create 
        [HttpPost]
        public IActionResult Create([Bind("subject")] CoursesModel course)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(course);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }

        //GET: /courses/edit/id
        public IActionResult Edit(int id)
        {
            var course = _db.Courses.ToList().Find(c => c.id == id);
            ViewData["course"] = course;
            return View();
        }

        //POST:  /courses/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("id", "subject")] CoursesModel course)
        {
            _db.Courses.Update(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST : /courses/delete/id
        public IActionResult Delete(int? id)
        {
            var course = _db.Courses.ToList().Find(c => c.id == id);
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
