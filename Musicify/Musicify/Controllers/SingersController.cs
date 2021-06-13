using Microsoft.AspNetCore.Mvc;
using Musicify.Data;
using Musicify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicify.Controllers
{
    public class SingersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SingersController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /Singers
        public IActionResult Index()
        {
            var Singers = _db.Singers.ToList();
            ViewData["Singers"] = Singers;
            return View();
        }

        // GET: /Singers/id
        public IActionResult Details(int? id)
        {
            var Singers = _db.Singers.ToList().Find(Singers => Singers.Id == id);
            if (id == null || Singers == null)
            {
                return View("_NotFound");
            }
            ViewData["Singers"] = Singers;
            return View(Singers);

        }

        // Create

        // GET: /Singers/create
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        // Post: /Singers/create
        [HttpPost]
        public IActionResult Create([Bind("Id", "Name", "Photo", "Info")] SingerModel Singers)
        {
            // if for validations
            if (ModelState.IsValid)
            {
                _db.Singers.Add(Singers);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Singers);
        }

        // Updte

        // GET: /Singers/edit/id
        public IActionResult Edit(int? id)
        {
            var Singers = _db.Singers.ToList().Find(p => p.Id == id);
            if (id == null || Singers == null)
            {
                return View("_NotFound");
            }
            ViewData["Singers"] = Singers;
            return View();
        }

        // POST: /Singers/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Photo", "Info")] SingerModel Singers)
        {
            _db.Singers.Update(Singers);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: /Singers/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Singers = _db.Singers.ToList().Find(p => p.Id == id);
            if (id == null || Singers == null)
            {
                return View("_NotFound");
            }
            _db.Singers.Remove(Singers);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
