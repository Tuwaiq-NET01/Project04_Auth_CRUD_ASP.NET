using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controllers
{
    public class Patients : Controller
    {
        private readonly ApplicationDbContext _db;

        public Patients(ApplicationDbContext context)
        {
            _db = context;
        }

        // READ -GET /Patients
        public IActionResult Index()
        {
            var Patients = _db.Patients.ToList();
            ViewData["Patients"] = Patients;
            return View(Patients);
        }

        //CREATE
        //GET - /Patients/create
        public IActionResult Create()
        {
            return View();
        }

        //POST - /Patients/create
        [HttpPost]
        public IActionResult Create([Bind("Id", "Name", "Gender", "DOB", "Phone", "Email")] Patient patients)
        {
            if (ModelState.IsValid)
            {
                _db.Patients.Add(patients);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        //UPDATE
        //GET - /Patients/edit/id
        public IActionResult Edit(int? id)
        {
            var Patients = _db.Patients.ToList().Find(a => a.Id == id);
            if (id == null || Patients == null)
            {
                return View("_NotFound");
            }
            ViewData["Patients"] = Patients;
            return View();
        }
        //POST - /Patients/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Gender", "DOB", "Phone", "Email")] Patient patients)
        {
            _db.Patients.Update(patients);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //DELETE
        // POST - /Patients/delete/id
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var patients = _db.Patients.ToList().Find(a => a.Id == id);
            _db.Patients.Remove(patients);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
