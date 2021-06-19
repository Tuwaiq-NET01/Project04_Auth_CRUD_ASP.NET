using Final_project.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Microsoft.AspNetCore.Authorization;

namespace Final_project.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            var Parking = _db.Parkings.ToList();
            ViewData["Parking"] = Parking;
           
            return View("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id", "AdminId")] ParkingModel parking)
        {
            if (ModelState.IsValid)
            {
                _db.Parkings.Add(parking);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parking);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var parking = _db.Parkings.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || parking == null)
            {
                return View("_NotFound");
            }
            _db.Parkings.Remove(parking);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
