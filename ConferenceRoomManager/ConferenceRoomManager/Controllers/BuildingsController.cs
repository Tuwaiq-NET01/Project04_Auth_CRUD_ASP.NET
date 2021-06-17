using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceRoomManager.Data;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomManager.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BuildingsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var buildings = _db.Buildings.Include("Rooms").ToList();
            ViewData["Buildings"] = buildings;
           
            return View();
        }

        public IActionResult Details(int? id)
        {
            var building = _db.Buildings.Include("Rooms").ToList().Find(building => building.Id == id);

            if (id == null || building == null)
            {
                return View("_NotFound");
            }
            ViewData["Building"] = building;
            return View();
        }
    }
}
