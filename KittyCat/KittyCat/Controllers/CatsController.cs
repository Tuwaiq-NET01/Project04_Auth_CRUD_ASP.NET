using KittyCat.Data;
using KittyCat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KittyCat.Controllers
{
    public class CatsController : Controller
    {
        private ApplicationDbContext _db;
        [ActivatorUtilitiesConstructor]
        public CatsController(ApplicationDbContext context)
        {
            _db = context; 
        }

        public CatsController()
        {
        }
        public IActionResult Index()
        {
            ViewData["Cats"] = _db.catTable.ToList();
            return View();
        }
        public IActionResult Index1()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDB").Options;
            var db = new ApplicationDbContext(options);
            ViewData["Cats"] = db.catTable.ToList();
            return View();
         }
    
        public IActionResult Details(int id)
        {
            var cat = _db.catTable.Where(c => c.id == id).ToList().First();
            var owner = _db.owner.Where(o => o.id == cat.OwnerId).ToList().First();
            var location = _db.location.Where(l => l.id == cat.LocationId).ToList().First();
            ViewData["Cat"] = cat;
            ViewData["Owner"] = owner;
            ViewData["Location"] = location;
            return View();
        }

        public IActionResult Delete(int id)
        {
            var cat = _db.catTable.Where(c => c.id == id).First();

            _db.catTable.Remove(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
