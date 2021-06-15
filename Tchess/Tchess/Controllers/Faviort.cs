using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Tchess.Data;
using Tchess.Models;

namespace Tchess.Controllers
{
    public class Faviort : Controller
    {
        private readonly ApplicationDbContext _db;

        public Faviort(ApplicationDbContext context)
        {
            _db = context;
        }
        // GET

        public IActionResult AddFaviorte(int id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Favirot f = new Favirot()
                {GameId = id, ProfileId = _db.Profiles.FirstOrDefault(profile => profile.UserId == userid).Id};
            _db.Favirots.Add(f);
            _db.SaveChanges();
            return Json("");
        }
    }
}