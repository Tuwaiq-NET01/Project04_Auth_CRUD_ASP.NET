
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
    [Microsoft.AspNetCore.Authorization.Authorize/*(Roles = "User")*/]

    public class InstructorsController : Controller
    {
        private readonly TechMEDbContext _db;

        public InstructorsController(TechMEDbContext context)
        {
            _db = context;
        }
        public IActionResult Index(int ID = 1) // هل لازم  زم يكون فية Id او لا
        {
            var Instructor = _db.Instructor.ToList();
            ViewData["Instructor"] = Instructor;
            ViewData["ID"] = ID;

            return View();
        }

        // GET: Instructor/ID
        [HttpGet]
        public IActionResult Details(int? ID)
        {
            var Instructor = _db.Instructor.ToList().Find(Instructor => Instructor.Instructor_ID == ID);
            var Course = _db.Course.ToList();

            if (ID == null || Instructor == null)
            {
                return View("_NotFound");
            }
            ViewData["Instructor"] = Instructor;
            ViewData["Course"] = Course;
            return View(Instructor);

        }
        // Create
        //GET - /Instructors/create
        public IActionResult Create()
        {
            return View();
        }

        //POST - /Instructors/create
        [HttpPost]
        public IActionResult Create([Bind("Instructor_Name","Instructor_Name", "Instructor_BIO", "Instructor_Image")] InstructorModel Instructors)
        {
            if (ModelState.IsValid) //check the state of modelSS
            {
                _db.Instructor.Add(Instructors);
                _db.SaveChanges();

            }
            return View(Instructors);
        }


        //GEt - /Instructors/edit/id
        public IActionResult Edit(int? ID)
        {
            var Instructor = _db.Instructor.ToList().Find(I => I.Instructor_ID == ID);
            if (ID == null || Instructor == null)
            {
                return View("_NotFound");
            }
            ViewData["Instructor"] = Instructor;
            return View();
        }
        //POST - /Instructor/edit/id
        [HttpPost]
        public IActionResult Edit(int ID, [Bind("Instructor_ID","Instructor_Name", "Instructor_Name", "Instructor_BIO", "Instructor_Image")] InstructorModel Instructor)
        {
            _db.Instructor.Update(Instructor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // POST - /Instructor/delete/id
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            var Instructor = _db.Instructor.ToList().FirstOrDefault(I => I.Instructor_ID == ID);
            /*if (ID == null || Course == null)
            {
                return View("_NotFound");
            }*/
            _db.Instructor.Remove(Instructor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
