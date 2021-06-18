using _Platform_.Data;
using _Platform_.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _Platform_.Controllers
{
    public class AmbassadorsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AmbassadorsController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Ambassadors = _db.ambassador.ToList();
            ViewData["Ambassadors"] = Ambassadors;
            return View();
        }

        public IActionResult Details(int? id = 1)
        {
            var ambassador = _db.ambassador.ToList().Find(a => a.Id == id);
            ViewData["ambassador"] = ambassador;

            if (ambassador == null)
            {
                return Content("Not found");
            }
            else
            {
                ViewData["ambassador"] = ambassador;
                return View();
            }
        }


        //GET - /Ambassadors/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST - /Ambassadors/Create
        [HttpPost]
        public IActionResult Create([Bind("Id", "FirstName", "LastName", "Description", "Email", "Image", "CharityId")] ambassador ambassador)
        {
            if (ModelState.IsValid) //check the state of model
            {
                _db.ambassador.Add(ambassador);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ambassador);
        }

        //GEt - /Ambassadors/Edit/id
        public IActionResult Edit(int? id)
        {
            var ambassador = _db.ambassador.ToList().Find(p => p.Id == id);
            if (id == null || ambassador == null)
            {
                return View("_NotFound");
            }
            ViewData["ambassador"] = ambassador;
            return View();
        }

        //POST - /Ambassadors/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "FirstName", "LastName", "Description", "Email", "Image", "CharityId")] ambassador ambassador)
        {

            _db.ambassador.Update(ambassador);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST - /Ambassadors/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var ambassador = _db.ambassador.ToList().FirstOrDefault(d => d.Id == id);
            if (id == null || ambassador == null)
            {
                return View("_NotFound");
            }
            _db.ambassador.Remove(ambassador);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
