﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationManagement.Models;
using HotelReservationManagement.Data;
using Microsoft.AspNetCore.Authorization;

namespace HotelReservationManagement.Controllers
{
    
    public class HotelsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HotelsController(ApplicationDbContext context)
        {
            _db = context;
        }

        //GET:/Hotels

        public IActionResult Index()
        {
            var Hotels = _db.Hotels.ToList();
            ViewData["Hotels"] = Hotels;
            return View();
        }

        //Get: /Hotels/id
        public IActionResult Details(int? id)
        {
            var Hotel = _db.Hotels.ToList().Find(p => p.HotelId == id);
            var Rooms = _db.Rooms.ToList();
            if (id == null || Hotel == null)
            {
                return View("_NotFound");
            }

            ViewData["Hotel"] = Hotel;
            ViewData["Rooms"] = Rooms;

            return View();
        }
        
        //GET - /hotels/create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create([Bind("HotelId", "HotelImage","HotelName", "City", "State", "ZipCode", "PhoneNumber")] HotelModel hotel)
        {
            if (ModelState.IsValid)//check the state of the model
            {
                _db.Hotels.Add(hotel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);

        }

        //GET: /Hotels/edit/id
        [Authorize]
        public IActionResult Edit(int? id)
        {
            var Hotel = _db.Hotels.ToList().Find(h => h.HotelId == id);
            if (id == null || Hotel == null)
            {
                return View("_NotFound");
            }
            ViewData["Hotel"] = Hotel;
            return View();
        }

        //POST: /Hotels/edit/id
        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, [Bind("HotelName","HotelImage" ,"City", "State", "ZipCode", "PhoneNumber")] HotelModel h)
        {

            var hotel = _db.Hotels.ToList().Find(p => p.HotelId == id);

            hotel.HotelName = h.HotelName;
            hotel.HotelImage = h.HotelImage;
            hotel.City = h.City;
            hotel.State = h.State;
            hotel.ZipCode = h.ZipCode;
            hotel.PhoneNumber = h.PhoneNumber;

            _db.Hotels.Update(hotel);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //POST - /Hotels/delete/id
        [HttpPost]
        [Authorize]
        public IActionResult Delete(int? id)
        {
            var hotel = _db.Hotels.ToList().FirstOrDefault(h => h.HotelId == id);
            if (id == null || hotel == null)
            {
                return View("_NotFound");
            }
            _db.Hotels.Remove(hotel);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
