using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musicify.Data;
using Musicify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicify.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public FavoritesController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var favList = _db.Favorites.Where(fav => fav.UserId == userId)
                .Include(fav => fav.Song).ToList();

            var favSongs = new List<SongModel>();

            foreach (var fav in favList)
                favSongs.Add(fav.Song);

            ViewData["Songs"] = favSongs;
            return View();
           
        }

        // POST: /Songs/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var userId = _userManager.GetUserId(User);
            var favs = _db.Favorites.First(f => f.SongId == id && f.UserId == userId);
            if (id == null || favs == null)
            {
                return View("_NotFound");
            }

            _db.Favorites.Remove(favs);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
