using HotelReservationManagement.Data;
using HotelReservationManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManagement.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AdvanceUser> _userManager;

        public BookingsController(UserManager<AdvanceUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _db = context;
        }

        

        //GET: /Bookings/Details/id
        public IActionResult Details(int? id)
        {
            var Booking = _db.RoomBookings.ToList().Find(b => b.RoomBookingId == id);
            if (id == null || Booking == null)
            {
                return View("_NotFound");
            }

            ViewData["Booking"] = Booking;

            return View();
        }

        //GET: /Bookings/Create/room/id
        [Authorize]
        public IActionResult Create(int id)
        {
            ViewData["RoomId"] = id;
            return View();
        }

        //POST: /Bookings/Create
        [HttpPost]
        [Authorize]
        public IActionResult Create(int id, [Bind("RoomId", "UserId", "BookingDate", "fromDate", "toDate","NumberOfGuests")] RoomBookingModel roomBooking)
        {
            roomBooking.RoomId = id;
            roomBooking.UserId = _userManager.GetUserId(HttpContext.User);
            AdvanceUser user = _userManager.FindByIdAsync(roomBooking.UserId).Result;
            roomBooking.BookingDate = DateTime.Now;

            //var bookings = _db.RoomBookings.Where(booking => booking.UserId == "32dd251c-5637-4e5f-a487-ea2e1afc506b").ToList();
            if (ModelState.IsValid)
            {
                _db.RoomBookings.Add(roomBooking);
                _db.SaveChanges();
                if(user.Admin == true)
                {
                    return RedirectToAction("Index");
                }
                if (user.Admin ==false)
                {
                    return RedirectToAction("UserBookingIndex");
                }
                
            }
            return View(roomBooking);
        }

        //GET: /Bookings
        public IActionResult UserBookingIndex()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
          
            AdvanceUser user = _userManager.FindByIdAsync(userid).Result;

            var bookings = _db.RoomBookings.Where(booking => booking.UserId == userid).ToList();
            var rooms = _db.Rooms.ToList();
            var hotels = _db.Hotels.ToList();
            //ViewData[]
            ViewData["user"] = user;
            ViewData["Bookings"] = bookings;
            ViewData["hotels"] = hotels;
            ViewData["rooms"] = rooms;

            return View();
        }
    }
}
      
      
        