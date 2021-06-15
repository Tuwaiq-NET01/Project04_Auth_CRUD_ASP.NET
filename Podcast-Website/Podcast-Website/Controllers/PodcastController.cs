using Microsoft.AspNetCore.Mvc;
using Podcast_Website.Data;
using Podcast_Website.ViewModel;
using Podcast_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Podcast_Website.Controllers
{
    public class PodcastController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;


        public PodcastController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        public IActionResult Index(int id = -1)
        {
            var Podcasts = _db.Podcasts.ToList();
            var Prodcast_Tag = _db.Prodcast_Tag.ToList();
            var tags = _db.Tags.ToList();


            ViewData["Podcasts"] = Podcasts;
            ViewData["Prodcast_Tag"] = Prodcast_Tag;
            ViewData["tags"] = tags;
            
            ViewData["id"] = id;

            return View();
        }

        public IActionResult Create(int id)
        {

           
            ViewData["id"] = id;
            

            return View();
        }

        [HttpPost]
        public IActionResult Create(TagAndPocast obj )
        {
            PodcastModel p = new PodcastModel();
            p.Title = obj.Title;
            p.Audio = obj.Audio;
            p.Podcast_image = obj.Podcast_image;
            p.Description = obj.Description;
            p.ProfileId = obj.ProfileId;
            _db.Podcasts.Add(p);
            _db.SaveChanges();


            int podcastId = p.Id;

            TagModel t = new TagModel();

            t.Tag_Name = obj.Tag_Name;

            _db.Tags.Add(t);
            _db.SaveChanges();

            int tagId = t.Id;

            Prodcast_TagModel tp = new Prodcast_TagModel();

            tp.Podcast__Id = podcastId;
            tp.TagId = tagId;


            _db.Prodcast_Tag.Add(tp);
            _db.SaveChanges();

            return RedirectToAction("Index", "Myprofile", new { area = "" });

        }

        public IActionResult Edit(int id)
        {
            var Podcasts = _db.Podcasts.ToList().Find(p => p.Id == id);
            if (id == null || Podcasts == null)
            {
                
            }
            ViewData["Podcasts"] = Podcasts;
            return View();
        }

        // Post - /poducts/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Title", "Audio", "Podcast_image", "Description", "ProfileId")] PodcastModel Podcast)
        {
            _db.Podcasts.Update(Podcast);
            _db.SaveChanges();
            return RedirectToAction("Index", "Myprofile", new { area = "" });
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Music = _db.Podcasts.ToList().Find(p => p.Id == id);
            if (id == null || Music == null)
            {
                return View("Error");
            }
            _db.Podcasts.Remove(Music);
            _db.SaveChanges();
             
            return RedirectToAction("Index", "Myprofile", new { area = "" });
        }

        [HttpPost]
        public IActionResult filter(string searchString, bool notUsed)
        {
            var Podcasts = _db.Podcasts.ToList();
            var Prodcast_Tag = _db.Prodcast_Tag.ToList();
            var tags = _db.Tags.ToList();

            var tagnames = searchString;
            string[] tagstring = tagnames.Split(',');

            ViewData["Podcasts"] = Podcasts;
            ViewData["Prodcast_Tag"] = Prodcast_Tag;
            ViewData["tags"] = tags;
            ViewData["tagstring"] = tagstring;

             ViewData["searchString"] = searchString;

            return View();
        }

        public IActionResult Details(int? id)
        {
            var Podcasts = _db.Podcasts.ToList();
            var Prodcast_Tag = _db.Prodcast_Tag.ToList();
            var tags = _db.Tags.ToList();
            var Profiles = _db.Profiles.ToList();


            PodcastModel Podcast = Podcasts.Find(b => b.Id == id);

            if (Podcast == null)
            {
                return View("Error");
            }
            else
            {
                ViewData["Podcast"] = Podcast;
                ViewData["userid"] = _userManager.GetUserId(HttpContext.User);
                ViewData["tags"] = tags;
                ViewData["Prodcast_Tag"] = Prodcast_Tag;

                
                ViewData["Profiles"] = Profiles;
                

                ViewData["id"] = id;
                return View();
            }
        }

    }
}
