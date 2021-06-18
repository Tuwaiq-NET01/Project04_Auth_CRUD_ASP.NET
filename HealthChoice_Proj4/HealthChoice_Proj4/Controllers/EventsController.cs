using HealthChoice_Proj4.Data;
using HealthChoice_Proj4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Final_crud_auth.Controllers
{
    public class EventsController : Controller
    {

        private readonly ApplicationDbContext _db;
        UserManager<IdentityUser> _userManager;
        [ActivatorUtilitiesConstructor]
        public EventsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        public EventsController()
        {
        }

        public IActionResult Index()
        {
            var Events = _db.Events.ToList();
      
            ViewData["Events"] = Events;
         

            return View();
        }

        //Get: /Events/details/id


        public IActionResult Details(int? id)
        {
            var Events = _db.Events.First(e => e.Id == id);
            if (id == null || Events == null)
            {
                return View("_NotFound");
            }
            ViewData["Events"] = Events;
         
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            var userId = _userManager.GetUserId(User);
            var Event = _db.Events.ToList().First(p => p.Id == id);

            if (id == null || Event == null || userId == null)
            {
                return View("_NotFound");
            }

            var fav = new FavoriteModel() { UserId = userId, EventId = Event.Id };
            _db.Favorites.Add(fav);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
