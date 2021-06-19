using System;
using System.Linq;
using AppStore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoriesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GeneralCategory(string category)
        {
            var apps = _db.Apps
                .Include(a => a.Ratings)
                .Where(a => a.GeneralCategory.ToLower() == category)
                .ToList();
            ViewBag.Apps = apps;
            return View("Apps");
        }

        [HttpGet]
        public IActionResult SpecificCategory(int id)
        {
            var apps = _db.AppsCategories
                .Include(a => a.App)
                .ThenInclude(a => a.Ratings)
                .Include(a => a.Category)
                .Where(c => c.CategoryId == id)
                .ToList();
            ViewBag.sApps = apps;
            return View("Apps");
        }
    }
}