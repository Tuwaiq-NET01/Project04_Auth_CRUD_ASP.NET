using KittyCat.Data;
using KittyCat.Models;
using Microsoft.AspNetCore.Mvc;
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
        public CatsController(ApplicationDbContext context)
        {
            _db = context;
        }

        int count = 0;
        List<CatModel> ss = new List<CatModel>();
        //public void getImages()
        //{
        //    dynamic Animals = JObject.Parse(FetchAPI.httpReq());
        //    foreach (var animal in Animals.animals)
        //    {
        //        if (animal.photos.Count > 0)
        //        {
        //            Console.WriteLine(animal.photos[0].large);
        //            ss.Add(new CatModel { image = animal.photos[0].large, description = animal.description, breed = animal.breeds.primary, gender = animal.gender, health = "spayed_neutered", name = animal.name });

        //            //modelBuilder.Entity<CatModel>().HasData(new CatModel { });
        //            count++;
        //        }
        //    }
        //    if (count < 30) { getImages(); }
        //}

        public IActionResult Index()
        {
            ViewData["Cats"] = _db.catTable.ToList();
           // ViewData["Cats"] = ss;

            return View();
        }
        public IActionResult Details(int id)
        {
            var cat = _db.catTable.Where(c => c.id == id).ToList().First();
            var owner = _db.owner.Where(o => o.id == cat.OwnerId).ToList().First();
            /*var location = _db.location.Where(l => l.id == cat.LocationId).ToList().First();*/
            ViewData["Cat"] = cat;
            ViewData["Owner"] = owner;
            /*ViewData["Location"] = location;*/
            return View();
        }
    }
}
