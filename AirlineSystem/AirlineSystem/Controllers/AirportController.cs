using AirlineSystem.Data;
using AirlineSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineSystem.Controllers
{
    public class AirportController : Controller
    {
        private readonly AppDbContext _db;

        public AirportController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Airports = _db.Airports.ToList();
            var Planes = _db.Planes.ToList();
            ViewData["Planes"] = Planes;
            return View(Airports);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind()] AirportModel airport)
        {
            if (ModelState.IsValid)
            {
                _db.Airports.Add(airport);
                _db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var Planes = _db.Planes.ToList();
            var Airport = _db.Airports.ToList().Find(airport => airport.AirportID == id);
            ViewData["Airport"] = Airport;
            ViewData["Planes"] = Planes;
            return View(Airport);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var airport = _db.Airports.ToList().Find(airport => airport.AirportID == id);
            if (id == 0 || airport == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["Airport"] = airport;
            return View(airport);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind()] AirportModel AirportUpdate)
        {
            var Airport = _db.Airports.ToList().Find(Airport => Airport.AirportID == id);
            Airport.AirportName = AirportUpdate.AirportName;
            Airport.AirportShort = AirportUpdate.AirportShort;
            Airport.CountryCity = AirportUpdate.CountryCity;
            _db.Airports.Update(Airport);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Airport = _db.Airports.ToList().Find(Airport => Airport.AirportID == id);
            _db.Airports.Remove(Airport);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
