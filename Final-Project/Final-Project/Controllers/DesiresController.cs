using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Controllers
{
    [Authorize]
    public class DesiresController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DesiresController(ApplicationDbContext context)
        {
            _db = context;
        }
/*
        public DesiresController()
        {
        }
*/
        public ViewResult Index1()
        {
            return View();
        }
        public IActionResult Index()
        {
            var desires = _db.Desires.ToList();
            ViewData["Desires"] = desires;
            var renters = _db.Renters.ToList();
            ViewData["Renters"] = renters;
            return View();
        }


        public IActionResult Details(int? id)
        {
            var desires = _db.Desires.ToList().Find(desires => desires.Id == id);
            ViewData["Desires"] = desires;
            return View(desires);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id", "Title", "Description",  "Img",  "RenterId")] DesireModel desires)
        {
            _db.Desires.Add(desires); ;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var desires = _db.Desires.ToList().Find(p => p.Id == id);
            return View(desires);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id", "Title", "Description", "Img", "RenterId")] DesireModel desires)
        {
            _db.Desires.Update(desires);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var desires = _db.Desires.ToList().Find(p => p.Id == id);
            _db.Desires.Remove(desires);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
