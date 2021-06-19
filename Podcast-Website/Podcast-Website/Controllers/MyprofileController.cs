using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Podcast_Website.Data;
using Podcast_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podcast_Website.Controllers
{
    public class MyprofileController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;


        public MyprofileController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            
            ViewData["userid"] = _userManager.GetUserId(HttpContext.User);
            var Profiles = _db.Profiles.ToList();
            var Podcasts = _db.Podcasts.ToList();
            ViewData["Profiles"] = Profiles;
            ViewData["Podcasts"] = Podcasts;
            return View();
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var Profiles = _db.Profiles.ToList().Find(p => p.Id == id);
            if (id == 0 || Profiles == null)
            {
                return View("NotFoundPage");

            }
            ViewData["Profiles"] = Profiles;
            return View();
        }

        // Post - /poducts/edit/id
        [Authorize]
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Image", "Background_Image", "UserId")] ProfileModel Profiles)
        {
            _db.Profiles.Update(Profiles);
            _db.SaveChanges();
            return RedirectToAction("Index", "Myprofile", new { area = "" });
        }


        public List<ProfileModel> GetallProfile()
        {
            return _db.Profiles.ToList();


        }

        public List<ProfileModel> EditProfile([Bind("Id", "Name", "Image", "Background_Image", "UserId")] ProfileModel Profiles)
        {
            _db.Profiles.Update(Profiles);
            _db.SaveChanges();
            return _db.Profiles.ToList();
        }
    }
}
