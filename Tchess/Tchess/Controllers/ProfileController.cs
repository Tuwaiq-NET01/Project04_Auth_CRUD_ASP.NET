using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tchess.Data;
using Tchess.Models;

namespace Tchess.Controllers
{
    public class ProfileController : Controller
    {
        // GET
        private readonly ApplicationDbContext _db;

        public ProfileController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Profile profile = _db.Profiles.FirstOrDefault(profile => profile.UserId == userid);
            var q = _db.Favirots.Where(e => e.Profile.Id == profile.Id).Select(e=>e.Game).ToList();
            ViewData["profile"] = profile;
            ViewData["games"] = q;
            ViewData["db"] = _db;
            return View();
        }
    }
}
