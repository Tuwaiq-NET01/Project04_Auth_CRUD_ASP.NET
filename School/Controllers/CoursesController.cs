using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CoursesController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index(bool? added = false, bool? deleted = false)
        {
            ViewData["Added"] = added;
            ViewData["Deleted"] = deleted;
            var Courses = _db.Courses.ToList();
            ViewData["Courses"] = Courses;
            return View();
        }
        public IActionResult Search(string txt)
        {
            ViewData["Added"] = false;
            ViewData["Deleted"] = false;
            var Courses = _db.Courses.Where(c => c.Title.Contains(txt)).ToList();
            ViewData["Courses"] = Courses;
            return View("Index");
        }

        public IActionResult Details(int? id)
        {
            var Course = _db.Courses.FirstOrDefault(c => c.CourseId == id);
            ViewBag.Course = Course;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Title")] Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Courses.Add(course);
                _db.SaveChanges();
                return RedirectToAction("Index", new { added = true });
            }

            return View(course);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = _db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["Course"] = course;
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Title")] Course course)
        {
            course.CourseId = id;
            _db.Courses.Update(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _db.Courses.FirstOrDefault(c => c.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }
            ViewBag.CourseId = course.CourseId;

            return View(course);
        }

        [HttpPost]
        public IActionResult Delete(int id, [Bind("Title")] Course course)
        {
            course.CourseId = id;
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index", new { deleted = true });
        }
    }
}
