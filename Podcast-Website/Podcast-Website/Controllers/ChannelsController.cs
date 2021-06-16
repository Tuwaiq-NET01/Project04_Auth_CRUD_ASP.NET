using Microsoft.AspNetCore.Mvc;
using Podcast_Website.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podcast_Website.Controllers
{
    public class ChannelsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ChannelsController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Profiles = _db.Profiles.ToList();
            ViewData["Profiles"] = Profiles;
            return View();
        }

        public IActionResult Details(int id)
        {
            var Profiles = _db.Profiles.ToList();
            var Podcasts = _db.Podcasts.ToList();
            ViewData["Profiles"] = Profiles;
            ViewData["Podcasts"] = Podcasts;
            ViewData["id"] = id;
            return View();
        }


    }
}
