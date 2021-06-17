using Coffee.Data;
using Coffee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Controllers
{
    public class RecommendationsController : Controller
    {
        private readonly AppDbContext _db;
        [ActivatorUtilitiesConstructor]
        public RecommendationsController(AppDbContext context)
        {
            _db = context;
        }

        public RecommendationsController()
        {
        }

        public IActionResult Index()
        {
            var Recommendations = _db.Recommendations.ToList();
            ViewData["Recommendations"] = Recommendations;
            return View();
        }
        public IActionResult Index2()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDB").Options;
            var db = new AppDbContext(options);

            var Recommendations = db.Recommendations.ToList();
            ViewData["Recommendations"] = Recommendations;
            return View();
        }
        public IActionResult Details(int? id)
        {
            var Recommendation = _db.Recommendations.ToList().Find(a => a.ID == id);
            ViewData["Recommendation"] = Recommendation;
            return View();

        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        public IActionResult Create([Bind("ID", "ItemName", "Image", "Description","Color", "AvailabilityLoc", "UserId")] Recommendation Recom)
        {
            if (ModelState.IsValid)
            {
                _db.Recommendations.Add(Recom);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Recom);

        }
        public IActionResult Edit(int? id)
        {
            var Recommendation = _db.Recommendations.ToList().Find(p => p.ID == id);

            if (id == null || Recommendation == null)
            {
                return View("_NotFound");
            }
            ViewData["Recommendation"] = Recommendation;
            return View();
        }
     

        //POST
        [HttpPost]
        public IActionResult Edit(int id, [Bind("ItemName", "Image", "Description", "Color", "AvailabilityLoc")] Recommendation Recom)
        {
            var Recommendation = _db.Recommendations.ToList().Find(p => p.ID == id);
            Recommendation.ItemName = Recom.ItemName;
            Recommendation.Image = Recom.Image;
            Recommendation.Description = Recom.Description;
            Recommendation.Color = Recom.Color;
            Recommendation.AvailabilityLoc = Recom.AvailabilityLoc;


            _db.Recommendations.Update(Recommendation);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Recommendation = _db.Recommendations.ToList().FirstOrDefault(p => p.ID == id);
            if (id == null || Recommendation == null)
            {
                return View("_NotFound");
            }
            _db.Recommendations.Remove(Recommendation);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
