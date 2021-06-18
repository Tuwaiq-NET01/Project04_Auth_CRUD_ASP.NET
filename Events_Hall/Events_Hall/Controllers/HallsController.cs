using Events_Hall.Data;
using Events_Hall.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events_Hall.Controllers
{
    public class HallsController : Controller
    {
        private readonly ApplicationDbContext _db;

        [ActivatorUtilitiesConstructor]
        public HallsController(ApplicationDbContext context)
        {
            _db = context;
        }

        public HallsController()
        {
        }

        [Authorize]
        public IActionResult Index()
        {
            var DbHalls = _db.Halls.ToList();
            ViewBag.Halls = DbHalls;
            return View();
        }

        public IActionResult Index1()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDB").Options;
            var db = new ApplicationDbContext(options);
            var DbHalls = db.Halls.ToList();
            ViewBag.Halls = DbHalls;
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {

            return View("Create");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create([Bind("Name", "Capacity", "Avaliability")] HallModel hall)
        {
            if (ModelState.IsValid)
            {
                _db.Halls.Add(hall);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
            var Hall = _db.Halls.ToList().Find(p => p.Id == id);
            if (id == null || Hall == null)
            {
                return View("_NotFound");
            }
            ViewData["Hall"] = Hall;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Avaliability", "Capacity")] HallModel hall)
        {
            _db.Halls.Update(hall);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var hall = _db.Halls.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || hall == null)
            {
                return View("_NotFound");
            }
            _db.Halls.Remove(hall);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
