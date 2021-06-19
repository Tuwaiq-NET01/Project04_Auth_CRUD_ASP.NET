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

        public IActionResult Search(string? AppName)
        {
            if (!String.IsNullOrEmpty(AppName))
            {
                var x = _db.Apps.Where(a => a.Name.ToLower().Contains(AppName.ToLower()))
                    .Include(a => a.Ratings)
                    .ToList();
                @ViewBag.Search = AppName;
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

        [HttpPost("/details/{id}")]
        public IActionResult Details(int id)
        {
            // Check If App Exist
            var app = _db.Apps.ToList().Find(a => a.Id == id);
            var userId = _userManager.GetUserId(User);
            if (app == null)
            {
                return View("_NotFound");
            }

            // Check If User Already Downloaded The App
            var appDownloads = _db.Downloads.ToList();
            var appDownload = appDownloads.Find(a => a.AppId == id);
            if (appDownload != null)
            {
                if (appDownload.UserId == _userManager.GetUserId(User))
                {
                    // TODO: App Already Downloaded View
                    return RedirectToAction("Index");
                }
            }

            var download = new DownloadModel()
            {
                AppId = id, UserId = userId, DownloadDate = DateTime.Now
            };
            // Increase App Downloads Count
            app.DownloadsCount = appDownloads.Where(a => a.AppId == id).Count() + 1;
            _db.Apps.Update(app);
            _db.Downloads.Add(download);
            _db.SaveChanges();

            return RedirectToAction("Index", "Accounts");
        }
    }
}