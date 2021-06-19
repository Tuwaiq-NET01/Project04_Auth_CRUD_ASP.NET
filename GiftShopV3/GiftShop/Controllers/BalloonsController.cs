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
    public class BalloonsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BalloonsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Balloons = _db.Balloons.ToList();
            ViewData["Balloons"] = Balloons;
            return View();
        }
        public IActionResult Details(int? id)
        {
            var Balloon = _db.Balloons.ToList().Find(Balloon => Balloon.BalloonId == id);
            if (id == null || Balloon == null)
            {
                return View("_NotFound");
            }
            ViewData["Balloon"] = Balloon;
            return View(Balloon);

        }
        // GET  - /Balloons/create
        public IActionResult Create()
        {
            return View();
        }
        // POST - /Balloons/create
        [HttpPost] // Binding doesn't have to be in order
        public IActionResult Create([Bind("BalloonImage", "BalloonName", "BalloonPrice")] BalloonModel Balloon)
        {
            if (ModelState.IsValid)
            {
                _db.Balloons.Add(Balloon);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        // GET  - /Balloons/edit/id
        public IActionResult Edit(int id)
        {
            var Balloon = _db.Balloons.ToList().Find(p => p.BalloonId == id);
            if (id == null || Balloon == null)
            {
                return View("_NotFound");
            }
            ViewData["Balloon"] = Balloon;
            return View();
        }
        // POST - /Balloons/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("BalloonId", "BalloonImage", "BalloonName", "BalloonPrice")] BalloonModel Balloon)
        {
            _db.Balloons.Update(Balloon);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST - /Balloons/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Balloon = _db.Balloons.ToList().Find(p => p.BalloonId == id);
            if (id == null || Balloon == null)
            {
                return View("_NotFound");
            }
            _db.Balloons.Remove(Balloon);
            _db.SaveChanges();
            return RedirectToAction("Index"); // => /Balloons
        }
    }
}
