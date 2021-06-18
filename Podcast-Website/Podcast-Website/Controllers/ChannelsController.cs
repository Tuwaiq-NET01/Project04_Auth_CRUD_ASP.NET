using Microsoft.AspNetCore.Mvc;
using Podcast_Website.Data;
using Podcast_Website.Models;
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

      

        public void CreateChannels(ProfileModel obj)
        {
            ProfileModel p = new ProfileModel();
            p.Id = obj.Id;
            p.Name = obj.Name;
            p.Image = obj.Image;
            p.Background_Image = obj.Background_Image;
            p.UserId = obj.UserId;
           
            _db.Profiles.Add(p);
            _db.SaveChanges();

        }

        public List<ProfileModel> GetallProfile()
        {
            return _db.Profiles.ToList();


        }

        public IActionResult Details(int id)
        {
           
            var Prodcast_Tag = _db.Prodcast_Tag.ToList();
            var tags = _db.Tags.ToList();
            var PodcastProfile = _db.PodcastProfile.ToList();


          
            ViewData["Prodcast_Tag"] = Prodcast_Tag;
            ViewData["tags"] = tags;
            ViewData["rating"] = PodcastProfile;



            var Profiles = _db.Profiles.ToList();
            var Podcasts = _db.Podcasts.ToList();
            ViewData["Profiles"] = Profiles;
            ViewData["Podcasts"] = Podcasts;
            ViewData["id"] = id;
            return View();
        }


    }
}
