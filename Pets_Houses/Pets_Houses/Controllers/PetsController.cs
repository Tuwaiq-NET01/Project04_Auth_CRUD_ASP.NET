using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pets_Houses.Data;
using Pets_Houses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_Houses.Controllers
{
    public class PetsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PetsController(ApplicationDbContext context)
        {
            _db = context;
        }
        
        public IActionResult Index()
        {
            var PetsInfo = _db.Pets.ToList();
            ViewData["PetsInfo"] = PetsInfo;
            return View();
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("UserId","Image","Type","Gender", "Details", "ContactNo")] PetModel Pet)
        {
            if (ModelState.IsValid)
            {
                _db.Pets.Add(Pet);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
            var Pet = _db.Pets.ToList().Find(p => p.Id == id);
            if (id == null && Pet == null)
            {
                return View("_NotFound");
            }
            ViewData["Pet"] = Pet;
            return View();
        }

        //post
        [HttpPost]
        public IActionResult Edit([Bind("Id", "UserId", "Image", "Type", "Gender", "Details", "ContactNo")] PetModel Pet)
        {
            _db.Pets.Update(Pet);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Pet = _db.Pets.ToList().Find(p => p.Id == id);
            if (id == null && Pet == null)
            {
                return View("_NotFound");
            }
            _db.Pets.Remove(Pet);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
