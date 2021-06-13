using Microsoft.AspNetCore.Mvc;
using Musicify.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Musicify.Models;
using Microsoft.EntityFrameworkCore;

namespace Musicify.Controllers
{
    public class SongsController : Controller
    {
        private static string baseUrl = "https://w.soundcloud.com/player/?url=";

        private readonly ApplicationDbContext _db;

        public SongsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /Songs
        public IActionResult Index()
        {
            //var Url = baseUrl + Url;
            var Songs = _db.Songs.ToList();
            foreach (var song in Songs) 
            {
                song.URL = baseUrl + song.URL;
            }
            ViewData["Songs"] = Songs;
            return View();
        }

        // GET: /Songs/id
        public IActionResult Details(int? id)
        {
            var Songs = _db.Songs.ToList().Find(Songs => Songs.Id == id);
            if (id == null || Songs == null)
            {
                return View("_NotFound");
            }
            ViewData["Songs"] = Songs;
            return View(Songs);

        }

        // Create

        // GET: /Songs/create
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        // Post: /Songs/create
        [HttpPost]
        public IActionResult Create([Bind("Id", "Name", "Type", "URL")] SongModel Songs)
        {
            // if for validations
            if (ModelState.IsValid)
            {
                _db.Songs.Add(Songs);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Songs);
        }

        // Updte

        // GET: /Songs/edit/id
        public IActionResult Edit(int? id)
        {
            var Songs = _db.Songs.ToList().Find(p => p.Id == id);
            if (id == null || Songs == null)
            {
                return View("_NotFound");
            }
            ViewData["Songs"] = Songs;
            return View();
        }

        // POST: /Songs/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Type", "URL")] SongModel Songs)
        {
            _db.Songs.Update(Songs);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: /Songs/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Songs = _db.Songs.ToList().Find(p => p.Id == id);
            if (id == null || Songs == null)
            {
                return View("_NotFound");
            }
            _db.Songs.Remove(Songs);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
