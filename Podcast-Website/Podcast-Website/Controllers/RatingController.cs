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
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;


        public RatingController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int rating123, int podcastid,int currentUser1)
        {
            if(rating123 == 0 || podcastid == 0 || currentUser1 == 0)
            {
                return View("Error");
            }
            PodcastProfileModel pp = new PodcastProfileModel();
            pp.Score = rating123;
            pp.Profile_Id = currentUser1;
            pp.PodcastId = podcastid;
            _db.PodcastProfile.Add(pp);
            _db.SaveChanges();


            return RedirectToAction("Details", "Podcast", new { id = podcastid });
           


        }
    }
}
