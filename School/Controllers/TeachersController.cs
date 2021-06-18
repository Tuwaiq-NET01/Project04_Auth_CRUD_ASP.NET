using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TeachersController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index(bool? added = false, bool? deleted = false)
        {
            ViewData["Added"] = added;
            ViewData["Deleted"] = deleted;
            var Teachers = _db.Teachers.ToList();
            ViewData["Teachers"] = Teachers;
            return View();
        }
        public IActionResult Search(string txt)
        {
            ViewData["Added"] = false;
            ViewData["Deleted"] = false;
            var Teachers = _db.Teachers.Where(t => t.FirstName.Contains(txt) || t.LastName.Contains(txt)).ToList();
            ViewData["Teachers"] = Teachers;
            return View("Index");
        }

        public IActionResult Details(int? id)
        {
            var Teacher = _db.Teachers.FirstOrDefault(t => t.TeacherId == id);
            ViewBag.Teacher = Teacher;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FirstName", "LastName", "Email")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Add(teacher);
                _db.SaveChanges();
                return RedirectToAction("Index", new { added = true });
            }

            return View(teacher);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = _db.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }
            ViewData["Teacher"] = teacher;
            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("FirstName", "LastName", "Email")] Teacher teacher)
        {
            teacher.TeacherId = id;
            _db.Teachers.Update(teacher);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = _db.Teachers.FirstOrDefault(t => t.TeacherId == id);

            if (teacher == null)
            {
                return NotFound();
            }
            ViewBag.TeacherId = teacher.TeacherId;

            return View(teacher);
        }

        [HttpPost]
        public IActionResult Delete(int id, [Bind("FirstName", "LastName", "Email")] Teacher teacher)
        {
            teacher.TeacherId = id;
            _db.Teachers.Remove(teacher);
            _db.SaveChanges();
            return RedirectToAction("Index", new { deleted = true });
        }
    }
}
