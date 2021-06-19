using HotelReservationManagement.Data;
using HotelReservationManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManagement.Controllers
{   [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AdvanceUser> _userManager;

        public AdminController(UserManager<AdvanceUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            
            _db = context;
        }

        [Authorize]

        public IActionResult AdminIndex()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            AdvanceUser user = _userManager.FindByIdAsync(userid).Result;

            if (user.Admin == true)
            {
                var Users = _userManager.Users.ToList();
                var bookings = _db.RoomBookings.ToList();
                var rooms = _db.Rooms.ToList();
                var hotels = _db.Hotels.ToList();
                ViewData["Users"] = Users;
                ViewData["Bookings"] = bookings;
                ViewData["hotels"] = hotels;
                ViewData["rooms"] = rooms;

                return View();
            }
            else
            {
                return View("_NotFound");
            }
        }

        public IActionResult UsersDetails()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            AdvanceUser user = _userManager.FindByIdAsync(userid).Result;
            if (user.Admin == true)
            {
                ViewData["users"] = _db.Users.ToList();
                return View();
            }
            else
            {
                return View("_NotFound");
            }
        }
        public IActionResult UserBookingDetails(string id)
        {
            AdvanceUser user = _userManager.FindByIdAsync(id).Result;
            var bookings = _db.RoomBookings.ToList().Find(booking => booking.UserId == id);
            if (id == null || bookings==null)
            {
                return View("_NotFound");
            }
            var rooms = _db.Rooms.ToList();
            var hotels = _db.Hotels.ToList();
            //ViewData[]
            ViewData["user"] = user;
            ViewData["Bookings"] = bookings;
            ViewData["hotels"] = hotels;
            ViewData["rooms"] = rooms;

            return View();
        }



        //GET: /Bookings/Create/
        [Authorize]
        public IActionResult AdminBookingCreate()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            AdvanceUser user = _userManager.FindByIdAsync(userid).Result;
            if (user.Admin == true)
            {
                ViewData["users"] = _db.Users.ToList();
                ViewData["rooms"] = _db.Rooms.ToList();
                ViewData["hotels"] = _db.Hotels.ToList();
                return View();

            }
            else
            {
                return View("_NotFound");
            }

        }

        //POST: /Bookings/Create
        [HttpPost]
        [Authorize]
        public IActionResult AdminBookingCreate([Bind("RoomId", "UserId", "BookingDate", "fromDate", "toDate", "NumberOfGuests")] RoomBookingModel booking)
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            AdvanceUser user = _userManager.FindByIdAsync(userid).Result;

            if (user.Admin == true && ModelState.IsValid)
            {
                _db.RoomBookings.Add(booking);
                _db.SaveChanges();
                return View(booking);

            }
            return View("_NotFound");
            //var bookings = _db.RoomBookings.Where(booking => booking.UserId == "32dd251c-5637-4e5f-a487-ea2e1afc506b").ToList(); 
        }

    }
}
