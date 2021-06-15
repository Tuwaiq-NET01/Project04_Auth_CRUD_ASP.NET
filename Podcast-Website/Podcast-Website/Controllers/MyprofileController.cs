using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Podcast_Website.Data;
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
        public IActionResult Index()
        {
            
            ViewData["userid"] = _userManager.GetUserId(HttpContext.User);
            var Profiles = _db.Profiles.ToList();
            var Podcasts = _db.Podcasts.ToList();
            ViewData["Profiles"] = Profiles;
            ViewData["Podcasts"] = Podcasts;
            return View();
        }
    }
}
