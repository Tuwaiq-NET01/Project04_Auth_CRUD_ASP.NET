using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mininet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Server.Kestrel;
using mininet.Data;
using Microsoft.AspNetCore.Identity;
using CodeHollow.FeedReader;

namespace mininet.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private static string rootFolder = Environment.CurrentDirectory;
        public ProfilesController(
            ApplicationDbContext context,
            UserManager<AppUser> userMgr
        )
        {
            _db = context;
            _userManager = userMgr;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var profile = _db.profiles.FirstOrDefault(p => p.UserId == userId);
            profile.Img = rootFolder + "/" + profile.Img;
            ViewData["profile"] = profile;
            return View();
        }
        public IActionResult Edit([FromRoute] long? id)
        {
            var userId = _userManager.GetUserId(User);
            var profile = _db.profiles.FirstOrDefault(p => p.Id == id && p.UserId == userId);
            if( id == null && profile == null)
                return View("_NotFound");
            ViewData["profile"] = profile;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind] ProfileModel profile)
        {
            if(ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                profile.UserId = userId;
                _db.profiles.Update(profile);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        [NonAction]
        public IActionResult EditTest(long? id)
        {
            
            var profile = _db.profiles.FirstOrDefault(p => p.Id == id);
            if( id == null && profile == null)
                return View("_NotFound");
            ViewData["profile"] = profile;
            return View("Edit");
            
        }
    }
}