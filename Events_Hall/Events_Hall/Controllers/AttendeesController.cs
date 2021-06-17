using Events_Hall.Data;
using Events_Hall.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events_Hall.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AttendeesController(ApplicationDbContext context)
        {
            _db = context;
        }
        //Attendees Dashboard, only avaliable for admins to view
        [Authorize]
        public IActionResult Index()
        {
            var DbAttendees = _db.Attendees.ToList();
            ViewBag.Attendees = DbAttendees;
            return View();
        }
        //Registering a new attendee from the admin's side
        [Authorize]
        public IActionResult Create()
        {

            return View("Create");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create([Bind("Name", "Email", "Phone", "Field", "EventId")] AttendeeModel attendee)
        {
            if (ModelState.IsValid)
            {
                _db.Attendees.Add(attendee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
            var Attendee = _db.Attendees.ToList().Find(p => p.Id == id);
            if (id == null || Attendee == null)
            {
                return View("_NotFound");
            }
            ViewData["Attendee"] = Attendee;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Email", "Phone", "Field", "EventId")] AttendeeModel attendee)
        {
            _db.Attendees.Update(attendee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Attendee = _db.Attendees.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Attendee == null)
            {
                return View("_NotFound");
            }
            _db.Attendees.Remove(Attendee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Search(int id)
        {

            var attendees = _db.Attendees.Where(d => d.EventId.Equals(id)).ToList();
            ViewBag.Attendees = attendees;

            return View("Index");
        }


    }
}
