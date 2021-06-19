using FinalProjectMVC.Data;
using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMVC.Controllers
{
    public class PlantsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public PlantsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var plants = _db.Plants.ToList();
            ViewData["plants"] = plants;
            return View(plants);
        }
        // GET: /plants/id
        public IActionResult Details(int? id)
        {
            var plants = _db.Plants.ToList().Find(plants => plants.PlantId == id);
            var plantcare = _db.PlantCares.ToList().Find(plants => plants.plantId == id);
            if (id == null || plants == null)
            {
                return View("_NotFound");
            }
            ViewData["plants"] = plants;
            ViewData["plantcare"] = plantcare;
            return View(plants);

        }

        //GET - /plants/edit/id
        public  IActionResult Edit(int? id)
        {
            var plants = _db.Plants.ToList().Find(b => b.PlantId == id);
            if (id == null || plants == null)
                {
                    return View("_NotFound");
                }
            ViewData["plants"] = plants;
            return View();
        }


        // POST - // plants/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("PlantId", "PlantName", "PlantType", "PlantColor", "PlantHeight", "Price")] PlantModel plants)
        {
            _db.Plants.Update(plants);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST -// plants/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var plants = _db.Plants.ToList().Find(b => b.PlantId == id);
            if (id == null || plants == null)
            {
                return View("_NotFound");
            }
            _db.Plants.Remove(plants);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [OneTimeSetUp]
        public IActionResult Edit2(int? id)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB").Options;

              var db = new ApplicationDbContext(options);

            var plants = db.Plants.ToList().Find(b => b.PlantId == id);
            if (id == null || plants == null)
            {
                return View("_NotFound");
            }
            ViewData["plants"] = plants;
            return View();
        }
        public IList<PlantModel> Execute()
        {
            return _db.Plants.ToList();
        }

    }
}

