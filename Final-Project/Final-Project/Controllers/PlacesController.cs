using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    [Authorize]
    public class PlacesController : Controller
    {
        private readonly ApplicationDbContext _db;



        public PlacesController(ApplicationDbContext context)
        {
            _db = context;
        }

/*        public PlacesController()
        {
        }*/

        public IActionResult Index()
        {
            var places = _db.Places.ToList();
            ViewData["Places"] = places;
            var lessors = _db.Lessors.ToList();
            ViewData["Lessors"] = lessors;
            var renters = _db.Renters.ToList();
            ViewData["Renters"] = renters;

            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            var places = _db.Places.ToList().Find(places => places.Id == id);
            ViewData["Places"] = places;
            return View(places);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id", "Title", "Description", "Price", "Lat", "Lng","Img", "LessorId", "RenterId")] PlaceModel places)
        {
            _db.Places.Add(places); ;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var places = _db.Places.ToList().Find(p => p.Id == id);
            return View(places);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id","Title", "Description", "Price", "Lat", "Lng", "Img", "LessorId", "RenterId")] PlaceModel places)
        {
            _db.Places.Update(places);
            _db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var places = _db.Places.ToList().Find(p => p.Id == id);
            _db.Places.Remove(places);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
