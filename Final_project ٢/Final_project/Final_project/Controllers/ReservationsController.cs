using Final_project.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Microsoft.AspNetCore.Identity;

namespace Final_project.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ReservationsController(ApplicationDbContext db )
        {
            _db = db;
        }

      

      
        public IActionResult Details(ReservationsModel reservations)
        {
            var Reservations = _db.Reservations.ToList();
            
            ReservationsModel reservation = Reservations.Find(reservation => reservation.Id == reservations.Id);

            if (reservation == null)
            {
                return Content("Not found your reservation");
            }
            else
            {
                ViewData["reservation"] = reservation;
             
                return View();
           }
        }

        public IActionResult History(string ? Id)
        {
            var Users = _db.Users.ToList();

            var Reservations = _db.Reservations.ToList();
            var user = Users.Find(user => user.Id == Id);
            if (user == null)
            {
                return Content("Not found User");

            }
            else
            {
                ViewData["reservations"] = Reservations;
                ViewData[" Users"] = Users;

                return View();
            }
        }



        //crud

        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id", "Date", "ParkingId","IDUser")] ReservationsModel reservations)
        {
            var ReservationList = _db.Reservations.ToList();

            ReservationsModel reservation = ReservationList.Find(reseevation => reseevation.ParkingId == reservations.ParkingId &&
            reseevation.Date == reservations.Date);
            if (reservation == null)
            {
                if (ModelState.IsValid)
                {
                    _db.Reservations.Add(reservations);
                    _db.SaveChanges();
                    return RedirectToAction("Details", reservations);
                }
            }
            else
            {
                ViewBag.Message = string.Format(" Oops! you need to change the date and Id parking because there " +
                    "is a reservation in the same parking and date");

            }
            return View();
        }

        //Edit
        public IActionResult Edit(int? id)
        {
            var reservation = _db.Reservations.ToList().Find(p => p.Id == id);
            if (id == null || reservation == null)
            {
                return Content("Not found your reservation");
            }
            ViewData["reservation"] = reservation;
            return View();
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id", "Date", "ParkingId","IDUser")] ReservationsModel reservation)
        {

            _db.Reservations.Update(reservation);
            _db.SaveChanges();

            return RedirectToAction("Index", "Parking");
        }
    }
}
