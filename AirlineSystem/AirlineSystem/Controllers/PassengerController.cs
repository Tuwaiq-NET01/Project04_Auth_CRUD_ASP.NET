using AirlineSystem.Data;
using AirlineSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AirlineSystem.Controllers
{
    public class PassengerController : Controller
    {
        private readonly AppDbContext _db;

        public PassengerController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Passengers = _db.Passengers.ToList();
            var Trips = _db.Trips.ToList();
            ViewData["Passenger"] = Passengers;
            ViewData["Trips"] = Trips;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("PassengerID", "PassportNo", "FirstName", "LastName", "DateOfBirth", "Gender", "Nationality","TripNo")]PassengerModel passenger)
        {
            if (ModelState.IsValid)
            {
                _db.Passengers.Add(passenger);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var Passenger = _db.Passengers.ToList().Find(passenger => passenger.PassengerID == id);
            ViewData["Passenger"] = Passenger;
            return View(Passenger);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Passenger = _db.Passengers.ToList().Find(passenger => passenger.PassengerID == id);
            ViewData["Passenger"] = Passenger;

            return View();
        }
        [HttpPost]
        public IActionResult Edit([Bind("PassengerID", "PassportNo", "FirstName", "LastName", "DateOfBirth", "Gender", "Nationality","TripNo")] PassengerModel passenger)
        {
            _db.Passengers.Update(passenger);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Passenger = _db.Passengers.ToList().Find(passenger => passenger.PassengerID == id);
            _db.Passengers.Remove(Passenger);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
