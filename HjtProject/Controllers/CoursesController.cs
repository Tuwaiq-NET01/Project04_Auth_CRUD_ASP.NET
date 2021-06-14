using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HjtProject.Areas.Identity.Pages.Account; // using this sh to transfer
using Microsoft.AspNetCore.Identity;
using HjtProject.Data;
using HjtProject.Models;

namespace HjtProject.Controllers
{
    public class CoursesController : Controller
    {
        /*List<IdentityUser> emails = RegisterModel.allUsers; // users*/

        /* public IActionResult Index()
         {
             *//*ViewData["users"] = emails;*//*

             return View();
         }*/

        private readonly ApplicationDbContext _db;

        public CoursesController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /courses
        public IActionResult Index()
        {
            var Courses = _db.Courses.ToList();
            ViewData["Courses"] = Courses;
            return View();
        }

        // GET: /courses/id
        public IActionResult Details(int? id)
        {
            var Course = _db.Courses.ToList().Find(course => course.Id == id);
            if (id == null || Course == null)
            {
                return View("_NotFound");
            }
            ViewData["Course"] = Course;
            return View(Course);

        }
       

        // Get - /courses/Create
        public IActionResult Create() 
        {
            return View();
        }

        // Post - /courses/create
        [HttpPost]
        public IActionResult Create([Bind("Id", "name", "description", "price","pic")] CourseModel course) // هذي تختلف عن اللي فوقها لان الطلب من الهتتمل مختلف عن بعض 
        {
            if (ModelState.IsValid) 
            {
                _db.Courses.Add(course); 
                _db.SaveChanges();
                return RedirectToAction("Index"); 

            }
            return View();

        }
        // Get - /courses/edit/id
        public IActionResult Edit(int id)
        {
            var course = _db.Courses.ToList().Find(p => p.Id == id); 
            if (id == null || course == null)
            {
                return View("_NotFound");
            }
            ViewData["Course"] = course;
            return View(); 
        }

        // POST - /courses/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "name", "description", "price","pic")] CourseModel course)
        {
            _db.Courses.Update(course);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }
        // Post - /courses/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var course = _db.Courses.ToList().Find(p => p.Id == id);
            if (id == null || course == null)
            {
                return View("_NotFound");
            }
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

