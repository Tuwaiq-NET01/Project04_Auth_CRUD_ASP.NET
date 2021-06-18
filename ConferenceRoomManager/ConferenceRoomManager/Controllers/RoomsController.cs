using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceRoomManager.Data;
using Microsoft.EntityFrameworkCore;

namespace ConferenceRoomManager.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RoomsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var rooms = _db.Rooms.Include("Facility").ToList();
            ViewData["Rooms"] = rooms;
            return View();
        }

        public IActionResult Details(int? id, string? msg)
        {
            var room = _db.Rooms.Include("Facility").Include("Building").ToList().Find(room => room.Id == id);

            if (id == null || room == null)
            {
                return View("_NotFound");
            }

            DateTime today = DateTime.Today;
            DateTime futureDate = today.AddDays(5);
            var todayString = today.ToString("yyyy/MM/dd");
            var futureDateString = futureDate.ToString("yyyy/MM/dd");

            var roomAvailable = _db.Bookings.Where(a => a.Id == id).ToList();
            
            
            ViewData["Room"] = room;
           
            
            if(msg != "")
            {
                ViewData["Msg"] = msg;
            }

            return View();
        }
    }
}
