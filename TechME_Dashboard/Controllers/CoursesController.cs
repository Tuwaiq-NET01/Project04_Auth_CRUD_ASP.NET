using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechME_Dashboard.Data;
using TechME_Dashboard.Models;


namespace TechME_Dashboard.Controllers
{
    public class CoursesController : Controller
    {
        private readonly TechMEDbContext _db;

        public CoursesController(TechMEDbContext context)
        {
            _db = context;
        }
        public IActionResult Index(int ID = 1) // هل لازم  زم يكون فية Id او لا
        {
            var Course = _db.Course.ToList();
            ViewData["Course"] = Course;
            ViewData["ID"] = ID;

            return View();
        }

        // GET: course/ID
        [HttpGet]
        public IActionResult Details(int? ID)
        {
            var Course = _db.Course.ToList().Find(Course => Course.Course_ID == ID);
            if (ID == null || Course == null)
            {
                return View("_NotFound");
            }
            ViewData["Course"] = Course;
            return View(Course);

        }

        // Create
        //GET - /Course/create
        public IActionResult Create()
        {
            return View();
        }

        //POST - /Courses/create
        [HttpPost]
        public IActionResult Create([Bind("Course_Name", "Course_Category", "Course_Description", "Course_Image")] CourseModel Courses)
        {
            if (ModelState.IsValid) //check the state of modelSS
            {
                _db.Course.Add(Courses);
                _db.SaveChanges();

            }
            return View(Courses);
        }


        //GEt - /Courses/edit/id
        public IActionResult Edit(int? ID)
        {
            var Course = _db.Course.ToList().Find(C => C.Course_ID == ID);
            if (ID == null || Course == null)
            {
                return View("_NotFound");
            }
            ViewData["Course"] = Course;
            return View();
        }
        //POST - /Courses/edit/id
        [HttpPost]
        public IActionResult Edit(int ID, [Bind("Course_ID", "Course_Name", "Course_Category", "Course_Description", "Course_Image")] CourseModel Course)
        {
            _db.Course.Update(Course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        // POST - /Course/delete/id
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            var Course = _db.Course.ToList().FirstOrDefault(C => C.Course_ID == ID);
            _db.Course.Remove(Course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
        
}


