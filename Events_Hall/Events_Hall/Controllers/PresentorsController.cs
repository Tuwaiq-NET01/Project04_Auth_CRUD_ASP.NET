using Events_Hall.Data;
using Events_Hall.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events_Hall.Controllers
{
    public class PresentorsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PresentorsController(ApplicationDbContext context)
        {
            _db = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var DbPresentors = _db.Presentors.ToList();
            ViewBag.Presentors = DbPresentors;
            return View();
        }
        [Authorize]
        public IActionResult Create()
        {

            return View("Create");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create([Bind("Name", "Email", "Phone", "Field")] PresentorModel presentor)
        {
            if (ModelState.IsValid)
            {
                _db.Presentors.Add(presentor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
            var Presentor = _db.Presentors.ToList().Find(p => p.Id == id);
            if (id == null || Presentor == null)
            {
                return View("_NotFound");
            }
            ViewData["Presentor"] = Presentor;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Email", "Phone", "Field")] PresentorModel presentor)
        {
            _db.Presentors.Update(presentor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Presentor = _db.Presentors.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Presentor == null)
            {
                return View("_NotFound");
            }
            _db.Presentors.Remove(Presentor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
