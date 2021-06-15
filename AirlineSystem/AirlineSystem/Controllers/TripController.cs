using AirlineSystem.Data;
using AirlineSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineSystem.Controllers
{
    public class TripController : Controller
    {
        private readonly AppDbContext _db;

        public TripController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Passangers = _db.Passengers.ToList();

            var Trips = _db.Trips.ToList();
            ViewData["Trips"] = Trips;
          //  ViewData["Passangers"] = Passangers;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("TripNo","Price","TripType", "TakeOffDateTime", "CabinClass", "RoadType", "Weight", "Destination")] TripModel Trip)
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine(Trip.Price);

                _db.Trips.Add(Trip);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var Trip = _db.Trips.ToList().Find(trip => trip.TripNo == id);
            ViewData["Trip"] = Trip;
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var Trip = _db.Trips.ToList().Find(trip => trip.TripNo == id);
            if(id==0|| Trip == null) {
                return RedirectToAction("Index");
            }
            ViewData["Trip"] = Trip;
            return View(Trip);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind( "Price", "TripType", "TakeOffDateTime", "CabinClass", "RoadType", "Weight", "Destination")] TripModel TripUpdate)
        {
           // var passenger = _db.Passengers.ToList().Find(pa=>pa.TripNo == id);
            var Trip = _db.Trips.ToList().Find(trip => trip.TripNo == id);
            Trip.TripType = TripUpdate.TripType;
            Trip.Price = TripUpdate.Price;
            Trip.TakeOffDateTime = TripUpdate.TakeOffDateTime;
            Trip.CabinClass = TripUpdate.CabinClass;
            Trip.RoadType = TripUpdate.RoadType;
            Trip.Destination = TripUpdate.Destination;
            
            Debug.WriteLine(TripUpdate.Price);
           _db.Trips.Update(Trip);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Trip = _db.Trips.ToList().Find(trip => trip.TripNo == id);
            _db.Trips.Remove(Trip);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
