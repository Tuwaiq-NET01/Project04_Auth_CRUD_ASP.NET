using _Platform_.Data;
using _Platform_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _Platform_.Controllers
{
    public class CharitiesController : Controller
    {
        private readonly ApplicationDbContext _db;


        public CharitiesController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var Charities = _db.Charity.ToList();
            ViewData["Charities"] = Charities;
            return View();
        }
        public IActionResult Search(string txt)
        {
            if (txt == null)
            {
                var Charities = _db.Charity.ToList();
                ViewData["Charities"] = Charities;
                return View("Index");
            }
            else
            {
                var search = _db.Charity.Where(d => d.CharityName.Contains(txt)).ToList();
                ViewData["Charities"] = search;
                return View("Index");
            }
        }
        public IActionResult settings()
        {
            var Charities = _db.Charity.ToList();
            ViewData["Charities"] = Charities;
            return View();
        }
        public IActionResult Details(int? id = 1)
        {
            var Charity = _db.Charity.ToList().Find(a => a.Id == id);
            ViewData["Charity"] = Charity;

            if (Charity == null)
            {
                return Content("Not found");
            }
            else
            {
                ViewData["Charity"] = Charity;
                return View();
            }
        }

        //GET - /Charities/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST - /Charities/Create
        [HttpPost]
        public IActionResult Create([Bind("Id", "CharityName", "Description", "Image", "Url", "UserId")] Charity Charity)
        {
            if (ModelState.IsValid) //check the state of model
            {
                _db.Charity.Add(Charity);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Charity);
        }

        //GEt - /Charities/Edit/id
        public IActionResult Edit(int? id)
        {
            var Charity = _db.Charity.ToList().Find(p => p.Id == id);
            if (id == null || Charity == null)
            {
                return View("_NotFound");
            }
            ViewData["Charity"] = Charity;
            return View();
        }

        //POST - /Charities/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "CharityName", "Description", "Image", "Url", "UserId")] Charity Charity)
        {

            _db.Charity.Update(Charity);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        // POST - /Charities/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Charity = _db.Charity.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Charity == null)
            {
                return View("_NotFound");
            }
            _db.Charity.Remove(Charity);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
