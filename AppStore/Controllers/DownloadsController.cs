using System;
using System.Linq;
using AppStore.Data;
using AppStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class DownloadsController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public DownloadsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        
        [HttpPost("/download/{id}")]
        public IActionResult Download(int id)
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
                    return RedirectToAction("Index","Apps");
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