using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controllers
{
    public class DocProfiles : Controller
    {

        private readonly ApplicationDbContext _db;

        public DocProfiles(ApplicationDbContext context)
        {
            _db = context;
        }

        // READ -GET /DocProfiles
        public IActionResult Index()
        {
            var DocP = _db.DocProfiles.ToList();
            ViewData["DocProfiles"] = DocP;
            var Docs = _db.Doctors.ToList();
            ViewData["Doctors"] = Docs;
            return View(DocP);
        }

        public IActionResult Details()
        {
            var DocP = _db.DocProfiles.ToList();
            ViewData["DocProfiles"] = DocP;
            var Docs = _db.Doctors.ToList();
            ViewData["Doctors"] = Docs;
            return View(DocP);
        }

        //CREATE
        //GET - /DocProfiles/create
        public IActionResult Create()
        {
            return View();
        }

        //POST - /DocProfiles/create
        [HttpPost]
        public IActionResult Create([Bind("Id", "Picture", "Degrees", "Awards")] DocProfile docp)
        {
            if (ModelState.IsValid)
            {
                _db.DocProfiles.Add(docp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        //UPDATE
        //GET - /DocProfiles/edit/id
        public IActionResult Edit(int? id)
        {
            var DocP = _db.DocProfiles.ToList().Find(a => a.Id == id);
            if (id == null || DocP == null)
            {
                return View("_NotFound");
            }
            ViewData["DocProfiles"] = DocP;
            return View();
        }

        //POST - /DocProfiles/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Picture", "Degrees", "Awards")] DocProfile docp)
        {
            _db.DocProfiles.Update(docp);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //DELETE
        // POST - /Doctors/delete/id
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var docp = _db.DocProfiles.ToList().Find(a => a.Id == id);
            _db.DocProfiles.Remove(docp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
