using HotelReservationManagement.Data;
using HotelReservationManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManagement.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AdvanceUser> _userManager;

        public BookingsController(UserManager<AdvanceUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _db = context;
        }
       
        //GET: /Bookings
        public IActionResult Index()
        {
            var userid = _userManager.GetUserId(HttpContext.User);

            if(userid != null)
            {
                AdvanceUser user = _userManager.FindByIdAsync(userid).Result;
                ViewData["user"] = user;
            }

            var Bookings = _db.RoomBookings.ToList();
            ViewData["Bookings"] = Bookings;
            return View();
        }

        //GET: /Bookings/Details/id
        public IActionResult Details(int? id)
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            if (userid != null)
            {
                AdvanceUser user = _userManager.FindByIdAsync(userid).Result;
                ViewData["user"] = user;
            }

            var Booking = _db.RoomBookings.ToList().Find(b => b.RoomBookingId == id);
            if (id == null || Booking ==null)
            {
                return View("_NotFound");
            }

            ViewData["Booking"] = Booking;
            return View();
        }


    }
}
