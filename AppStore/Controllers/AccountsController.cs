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

        public IActionResult Index()
        {
            var UserDownloads = _db.Apps
                .Include(a => a.Downloads.Where(d=>d.UserId == _userManager.GetUserId(User)))
                .Include(r=>r.Ratings.Where(d=>d.UserId == _userManager.GetUserId(User)))
                .ToList();
            ViewBag.UserDownloads = UserDownloads;
            return View();
        }
    }
}