using HjtProject.Data;
using HjtProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HjtProject.Controllers
{
    [Authorize]
    public class InstructorsController : Controller
    {
        /*List<IdentityUser> emails = RegisterModel.allUsers; // users*/

        /* public IActionResult Index()
         {
             *//*ViewData["users"] = emails;*//*

             return View();
         }*/

        private readonly ApplicationDbContext _db;

        public InstructorsController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /instructors
        public IActionResult Index()
        {
            var instructors = _db.Instructors.ToList();
            ViewData["instructors"] = instructors;
            return View();
        }

        // GET: /instructors/id
        public IActionResult Details(int? id)
        {
            var instructor = _db.Instructors.ToList().Find(instructor => instructor.Id == id);
            if (id == null || instructor == null)
            {
                return View("_NotFound");
            }
            ViewData["instructor"] = instructor;
            return View(instructor);

        }


        // Get - /instructors/Create
        public IActionResult Create()
        {
            return View();
        }

        // Post - /instructors/create
        [HttpPost]
        public IActionResult Create([Bind("name", "summary",  "pic", "OrganizationId")] InstructorModel instructor) 
        {
            if (ModelState.IsValid)
            {
              
                _db.Instructors.Add(instructor);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();

        }
        // Get - /instructors/edit/id
        public IActionResult Edit(int id)
        {
            var instructor = _db.Instructors.ToList().Find(p => p.Id == id);
            if (id == null || instructor == null)
            {
                return View("_NotFound");
            }
            ViewData["instructor"] = instructor;
            return View();
        }

        // POST - /instructors/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("name", "summary", "pic", "OrganizationId")] InstructorModel instructor)
        {
            EntityEntry<InstructorModel> entry = _db.Entry(instructor);
            entry.Property(e => e.name).IsModified = true;
            entry.Property(e => e.summary).IsModified = true;
            entry.Property(e => e.pic).IsModified = true;
            entry.Property(e => e.OrganizationId).IsModified = true;
            // _db.instructors.Update(instructor);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }
        // Post - /instructors/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var instructor = _db.Instructors.ToList().Find(p => p.Id == id);
            if (id == null || instructor == null)
            {
                return View("_NotFound");
            }
            _db.Instructors.Remove(instructor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
