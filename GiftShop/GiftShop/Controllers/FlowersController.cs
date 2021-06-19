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
    public class FlowersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FlowersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Flowers = _db.Flowers.ToList();
            ViewData["Flowers"] = Flowers;
            return View();
        }
        public IActionResult Details(int? id)
        {
            var Flower = _db.Flowers.ToList().Find(Flower => Flower.FlowerId == id);
            if (id == null || Flower == null)
            {
                return View("_NotFound");
            }
            ViewData["Flower"] = Flower;
            return View(Flower);

        }
        // GET  - /Flowers/create
        public IActionResult Create()
        {
            return View();
        }
        // POST - /Flowers/create
        [HttpPost] // Binding doesn't have to be in order
        public IActionResult Create([Bind("FlowerImage, FlowerName, FlowerPrice")] FlowerModel Flower)
        {
            if (ModelState.IsValid)
            {
                _db.Flowers.Add(Flower);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        // GET  - /Flowers/edit/id
        public IActionResult Edit(int id)
        {
            var Flower = _db.Flowers.ToList().Find(p => p.FlowerId == id);
            if (id == null || Flower == null)
            {
                return View("_NotFound");
            }
            ViewData["Flower"] = Flower;
            return View();
        }
        // POST - /Flowers/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "FlowerImage", "FlowerName", "FlowerPrice")] FlowerModel Flower)
        {
            _db.Flowers.Update(Flower);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST - /Flowers/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Flower = _db.Flowers.ToList().Find(p => p.FlowerId == id);
            if (id == null || Flower == null)
            {
                return View("_NotFound");
            }
            _db.Flowers.Remove(Flower);
            _db.SaveChanges();
            return RedirectToAction("Index"); // => /Flowers
        }
    }
}