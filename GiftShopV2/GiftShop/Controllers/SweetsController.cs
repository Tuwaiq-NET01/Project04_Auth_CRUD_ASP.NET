using GiftShop.Data;
using GiftShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Controllers
{
    [Authorize]
    public class SweetsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SweetsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Sweets = _db.Sweets.ToList();
            ViewData["Sweets"] = Sweets;
            return View();
        }
        public IActionResult Details(int? id)
        {
            var Sweet = _db.Sweets.ToList().Find(Sweet => Sweet.SweetId == id);
            if (id == null || Sweet == null)
            {
                return View("_NotFound");
            }
            ViewData["Sweet"] = Sweet;
            return View(Sweet);

        }
        // GET  - /Sweets/create
        public IActionResult Create()
        {
            return View();
        }
        // POST - /Sweets/create
        [HttpPost] // Binding doesn't have to be in order
        public IActionResult Create([Bind("SweetId", "SweetImage", "SweetName", "SweetPrice")] SweetModel Sweet)
        {
            if (ModelState.IsValid)
            {
                _db.Sweets.Add(Sweet);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        // GET  - /Sweets/edit/id
        public IActionResult Edit(int id)
        {
            var Sweet = _db.Sweets.ToList().Find(p => p.SweetId == id);
            if (id == null || Sweet == null)
            {
                return View("_NotFound");
            }
            ViewData["Sweet"] = Sweet;
            return View();
        }
        // POST - /Sweets/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("SweetId", "SweetImage", "SweetName", "SweetPrice")] SweetModel Sweet)
        {
            _db.Sweets.Update(Sweet);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST - /Sweets/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Sweet = _db.Sweets.ToList().Find(p => p.SweetId == id);
            if (id == null || Sweet == null)
            {
                return View("_NotFound");
            }
            _db.Sweets.Remove(Sweet);
            _db.SaveChanges();
            return RedirectToAction("Index"); // => /Sweets
        }
    }
}
