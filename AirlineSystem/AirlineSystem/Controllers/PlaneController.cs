using AirlineSystem.Data;
using AirlineSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineSystem.Controllers
{
    public class PlaneController : Controller
    {
        private readonly AppDbContext _db;

        public PlaneController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Planes = _db.Planes.ToList();
            return View(Planes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind()] PlaneModel plane)
        {
            if (ModelState.IsValid)
            {
              
                _db.Planes.Add(plane);
                _db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var Plane = _db.Planes.ToList().Find(plane => plane.PlaneID == id);
            ViewData["Plane"] = Plane;
            return View(Plane);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var plane = _db.Planes.ToList().Find(plane => plane.PlaneID == id);
            if (id == 0 || plane == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["plane"] = plane;
            return View(plane);
        }
        [HttpPost]
        public IActionResult Edit(int id,[Bind()]PlaneModel PlaneUpdate)
        {
            var Plane = _db.Planes.ToList().Find(Plane => Plane.PlaneID == id);
            Plane.PlaneType = PlaneUpdate.PlaneType;
            Plane.PlaneName = PlaneUpdate.PlaneName;
            Plane.Capacity = PlaneUpdate.Capacity;
            _db.Planes.Update(Plane);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
           var plane = _db.Planes.ToList().Find(Plane => Plane.PlaneID == id);
            _db.Planes.Remove(plane);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
