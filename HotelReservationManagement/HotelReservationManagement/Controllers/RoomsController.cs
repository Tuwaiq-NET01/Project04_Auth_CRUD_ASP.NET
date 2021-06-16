using HotelReservationManagement.Data;
using HotelReservationManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManagement.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RoomsController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            var Rooms = _db.Rooms.ToList();
            ViewData["Rooms"] = Rooms;
            return View();
        }

        public IActionResult Details( int? id)
        {
            var Room = _db.Rooms.ToList().Find(r =>r.RoomId ==id);
            if(id ==null || Room == null)
            {
                return View("_NotFound");
            }
            ViewData["Room"] = Room;
            return View();
        }

        //GET:/Rooms/Create/hotel/id
       
        public IActionResult Create(int id)
        {
            ViewData["HotelId"] = id;
            
            return View();
        }

        //Post:/Rooms/Create/hotel/id
        [HttpPost]
       
        public IActionResult Create(int id, [Bind("RoomId","RoomNumber", "RoomImage","RoomPrice","RoomType","RoomDescribtion","RoomStatus")] RoomModel room)
        {
            room.HotelId = id;

            if (ModelState.IsValid)
            {
                
                _db.Rooms.Add(room);
                _db.SaveChanges();
                return RedirectToAction("Details","Hotels", new { id = room.HotelId});
                

            }
            return View(room); 
        }
        //GET: /Rooms/edit/id
        public IActionResult Edit(int? id)
        {
            var Room = _db.Rooms.ToList().Find(h => h.RoomId == id);
            if (id == null || Room == null)
            {
                return View("_NotFound");
            }
            ViewData["Room"] = Room;
            return View();
        }

        //POST: /Rooms/edit/id
        [HttpPost]
        public IActionResult Edit(int id, [Bind("RoomId", "RoomNumber", "RoomImage", "RoomPrice", "RoomType", "RoomDescribtion", "RoomStatus")] RoomModel r)
        {

            var room = _db.Rooms.ToList().Find(p => p.RoomId == id);

            room.RoomType = r.RoomType;
            room.RoomPrice = r.RoomPrice;
            room.RoomNumber = r.RoomNumber;
            room.RoomStatus = r.RoomStatus;
            room.RoomImage = r.RoomImage;
            room.RoomDescribtion = r.RoomDescribtion;


            _db.Rooms.Update(room);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //POST - /Hotels/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var room = _db.Rooms.ToList().FirstOrDefault(h => h.RoomId == id);
            if (id == null || room == null)
            {
                return View("_NotFound");
            }
            _db.Rooms.Remove(room);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
