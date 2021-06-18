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
    public class StudentsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public StudentsController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index(bool? added = false, bool? deleted = false)
        {
            ViewData["Added"] = added;
            ViewData["Deleted"] = deleted;
            var Students = _db.Students.ToList();
            ViewData["Students"] = Students;
            return View();
        }
        public IActionResult Search(string txt)
        {
            ViewData["Added"] = false;
            ViewData["Deleted"] = false;
            var Students = _db.Students.Where(s => s.FirstName.Contains(txt) || s.LastName.Contains(txt)).ToList();
            ViewData["Students"] = Students;
            return View("Index");
        }

        public IActionResult Details(int? id)
        {
            var Student = _db.Students.FirstOrDefault(s => s.StudentId == id);
            ViewBag.Student = Student;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FirstName", "LastName", "Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                return RedirectToAction("Index", new { added = true });
            }

            return View(student);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = _db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["Student"] = student;
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("FirstName", "LastName", "Email")] Student student)
        {
            student.StudentId = id;
            _db.Students.Update(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _db.Students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }
            ViewBag.StudentId = student.StudentId;

            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(int id, [Bind("FirstName", "LastName", "Email")] Student student)
        {
            student.StudentId = id;
            _db.Students.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index", new { deleted = true });
        }
    }
}
