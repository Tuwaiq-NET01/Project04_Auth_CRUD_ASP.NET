using System;
using System.Linq;
using AppStore.Data;
using AppStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        // GET

        public IActionResult Index(/*This Parameter Added For Unit Testing :( */string fakeId = "")
        {
            // This Code Added For Unit Test :(
            if (!String.IsNullOrEmpty(fakeId))
            {
                var UserDownloads2 = _db.Apps
                    .Include(a => a.Downloads.Where(d=>d.UserId == fakeId))
                    .Include(r=>r.Ratings.Where(d=>d.UserId ==fakeId))
                    .ToList();
                ViewBag.UserDownloads = UserDownloads2;
                return View();
            }
            
            var UserDownloads = _db.Apps
                .Include(a => a.Downloads.Where(d=>d.UserId == _userManager.GetUserId(User)))
                .Include(r=>r.Ratings.Where(d=>d.UserId == _userManager.GetUserId(User)))
                .ToList();
            ViewBag.UserDownloads = UserDownloads;
            return View();
        }
    }
}