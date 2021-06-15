using HealthChoice_Final_crud_auth.Data;
using HealthChoice_Final_crud_auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Final_crud_auth.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public FavouriteController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var favList = _db.Favorites.Where(f => f.UserId == userId)
              .Include(f => f.Events).ToList();

            var favEvents = new List<EventsModel>();

            foreach (var fav in favList)
                favEvents.Add(fav.Events);

            ViewData["favEvents"] = favEvents;
            return View();

        }

        // POST: /Events/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var userId = _userManager.GetUserId(User);
            var Favorits = _db.Favorites.First(f => f.EventId == id && f.UserId == userId);
            if (id == null || Favorits == null)
            {
                return View("_NotFound");
            }

            _db.Favorites.Remove(Favorits);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}



