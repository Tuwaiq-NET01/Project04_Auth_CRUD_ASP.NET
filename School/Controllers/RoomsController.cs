using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RoomsController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index(bool? added = false, bool? deleted = false)
        {
            ViewData["Added"] = added;
            ViewData["Deleted"] = deleted;
            var Rooms = _db.Rooms.ToList();
            ViewData["Rooms"] = Rooms;
            return View();
        }
        
        public IActionResult Details(int? id)
        {
            var Room = _db.Rooms.FirstOrDefault(r => r.RoomId == id);
            ViewBag.Room = Room;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("RoomSize")] Room room)
        {
            if (ModelState.IsValid)
            {
                _db.Rooms.Add(room);
                _db.SaveChanges();
                return RedirectToAction("Index", new { added = true });
            }

            return View(room);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var room = _db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["Room"] = room;
            return View(room);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("RoomSize")] Room room)
        {
            room.RoomId = id;
            _db.Rooms.Update(room);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = _db.Rooms.FirstOrDefault(r => r.RoomId == id);

            if (room == null)
            {
                return NotFound();
            }
            ViewBag.RoomId = room.RoomId;

            return View(room);
        }

        [HttpPost]
        public IActionResult Delete(int id, [Bind("RoomSize")] Room room)
        {
            room.RoomId = id;
            _db.Rooms.Remove(room);
            _db.SaveChanges();
            return RedirectToAction("Index", new { deleted = true });
        }
    }
}
