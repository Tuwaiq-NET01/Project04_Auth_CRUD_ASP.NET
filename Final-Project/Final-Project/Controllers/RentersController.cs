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
    public class RentersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RentersController(ApplicationDbContext context)
        {
            _db = context;
        }
/*
        public RentersController()
        {
        }
*/
        public ViewResult Index1()
        {
            return View();
        }
        public IActionResult Index()
        {
            var renters = _db.Renters.ToList();
            ViewData["Renters"] = renters;

            return View();
        }


        public IActionResult Details(int? id)
        {
            var renters = _db.Renters.ToList().Find(renters => renters.Id == id);
            ViewData["Renters"] = renters;
            return View(renters);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id", "Name", "Email", "PhoneNum")] RenterModel renters)
        {
            _db.Renters.Add(renters); ;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var renters = _db.Renters.ToList().Find(p => p.Id == id);
            return View(renters);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Email", "PhoneNum")] RenterModel renters)
        {
            _db.Renters.Update(renters);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var renters = _db.Renters.ToList().Find(p => p.Id == id);
            _db.Renters.Remove(renters);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}