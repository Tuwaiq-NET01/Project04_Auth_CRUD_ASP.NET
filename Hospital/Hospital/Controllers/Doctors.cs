using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controllers
{
    public class Doctors : Controller
    {
        private readonly ApplicationDbContext _db;

        public Doctors(ApplicationDbContext context)
        {
            _db = context;
        }

        // READ -GET /Doctors
        public IActionResult Index()
        {
            var Docs = _db.Doctors.ToList();
            ViewData["Doctors"] = Docs;
            return View(Docs);
        }

        //CREATE
        //GET - /Doctors/create
        public IActionResult Create()
        {
            return View();
        }

        //POST - /Doctors/create
        [HttpPost]
        public IActionResult Create([Bind("Id", "Name", "Gender", "Speciality", "Phone", "Email")] Doctor docs)
        {
            if (ModelState.IsValid)
            {
                _db.Doctors.Add(docs);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        //UPDATE
        //GET - /Doctors/edit/id
        public IActionResult Edit(int? id)
        {
            var Docs = _db.Doctors.ToList().Find(a => a.Id == id);
            if (id == null || Docs == null)
            {
                return View("_NotFound");
            }
            ViewData["Doctors"] = Docs;
            return View();
        }

        //POST - /Doctors/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Gender", "Speciality", "Phone", "Email")] Doctor docs)
        {
            _db.Doctors.Update(docs);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //DELETE
        // POST - /Doctors/delete/id
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var docs = _db.Doctors.ToList().Find(a => a.Id == id);
            _db.Doctors.Remove(docs);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
