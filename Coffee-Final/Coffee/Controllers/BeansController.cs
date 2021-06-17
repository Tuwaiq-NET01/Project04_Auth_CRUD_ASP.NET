using Coffee.Data;
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
    public class BeansController : Controller
    {
        private readonly AppDbContext _db;

        public BeansController()
        {
        }
        [ActivatorUtilitiesConstructor]
        public BeansController(AppDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Beans = _db.Beans.ToList();
            ViewData["Beans"] = Beans;
            return View();
        }

        public IActionResult Index2()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDB").Options;
            var db = new AppDbContext(options);

            var Beans = db.Beans.ToList();
            ViewData["Beans"] = Beans;
            return View("Index");
        }


    }
}
