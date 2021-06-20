using GreenLifeStore.Data;
using GreenLifeStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GreenLifeStore.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var Products = _db.Products.ToList();

            ViewData["Products"] = Products;

            return View();
        }

        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult HomeIndex()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "TestDB").Options;
            var db = new ApplicationDbContext(options);

            var products = db.Products.ToList();
            ViewData["Products"] = products;

            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
