using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using AppStore.Data;
using AppStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Controllers
{
    public class AppsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        // GET
        public IActionResult Index()
        {
            var x = _db.Apps.Include(a => a.Ratings).ToList();

            @ViewBag.Apps = x;

            return View();
        }

        public IActionResult Search(string appName)
        {
            if (!String.IsNullOrEmpty(appName))
            {
                var x = _db.Apps.Where(a => a.Name.ToLower().Contains(appName.ToLower()))
                    .Include(a => a.Ratings)
                    .ToList();
                @ViewBag.Search = appName;
                @ViewBag.Apps = x;
                return View("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet("/details/{id}")]
        public IActionResult Details(int? id)
        {
            var App = _db.Apps
                .Include(a => a.AppCategory)
                .ThenInclude(c => c.Category)
                .Include(a => a.Ratings)
                .ThenInclude(u => u.User)
                .Include(a => a.Downloads)
                .ToList().Find(app => app.Id == id);

            if (id == null || App == null)
            {
                return View("_NotFound");
            }

            ViewBag.App = App;
            return View();
        }
        
    }
}