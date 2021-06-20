using Microsoft.AspNetCore.Mvc;
using Musicify.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Musicify.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Musicify.Controllers
{
    [Authorize]
    public class SongsController : Controller
    {
        private static string baseUrl = "https://w.soundcloud.com/player/?url=";

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public SongsController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        /*// if you want to do test unComment from constrakter 
        // FOR TEST
        public SongsController(ApplicationDbContext db)
        {
            _db = db;
           
        }*/

        // GET: /Songs
        public IActionResult Index()
        {
            var Songs = _db.Songs.ToList();
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
            var listOfSingers = _db.Singers.ToList();
            ViewData["listOfSingers"] = listOfSingers;
            return View();

        }

        // Post: /Songs/create
        [HttpPost]
        public IActionResult Create([Bind( "Id","Name", "Type", "URL", "SingerId")] SongModel song)
        {
            // if for validations
            if (ModelState.IsValid)
            {   
                song.URL = baseUrl + song.URL;
                _db.Songs.Add(song);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(song);
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
        public IActionResult Edit([Bind()] SongModel Songs)
        {
            EntityEntry<SongModel> entry = _db.Entry(Songs);
            entry.Property(e => e.Name).IsModified = true;
            entry.Property(e => e.Type).IsModified = true;
           //  _db.Songs.Update(Songs);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: /Songs/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Songs = _db.Songs.ToList().Find(p => p.Id == id);
            var favs = _db.Favorites.Where(f => f.SongId == id).ToList();
            if (id == null || Songs == null)
            {
                return View("_NotFound");
            }
            favs.ForEach(f => _db.Favorites.Remove(f));
            _db.Songs.Remove(Songs);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            var userId = _userManager.GetUserId(User);
            var Songs = _db.Songs.ToList().First(p => p.Id == id);

            if (id == null || Songs == null || userId == null)
            {
                return View("_NotFound");
            }

            var fav = new FavoriteModel() { UserId = userId, SongId = Songs.Id };
            _db.Favorites.Add(fav);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ChoosePlayList(int? id) // Song Id
        {
            var Song = _db.Songs.First(p => p.Id == id);
            var userList = _db.PlayLists.Where(a => a.UserId == _userManager.GetUserId(User)).ToList();
            if (id == null || Song == null)
            {
                return View("_NotFound");
            }

            ViewData["List"] = userList;
            ViewData["Song"] = Song;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToPL([Bind("SongId", "PlayListId")] PlayListSongModel playListSong)
        {

            _db.playListSongs.Add(playListSong);  
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // UT test for delete
        public void DeleteSong(int id)
        {
            var Songs = _db.Songs.ToList().Find(p => p.Id == id);
            if (id == null || Songs == null)
            {
                throw new NullReferenceException();
            }
            _db.Songs.Remove(Songs);
            _db.SaveChanges();
        }

        public List<SongModel> getAllSongs()
        {
            return _db.Songs.ToList();

        }

    }
}
