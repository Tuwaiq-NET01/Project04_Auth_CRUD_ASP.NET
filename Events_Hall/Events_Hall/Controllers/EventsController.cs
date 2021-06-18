using Events_Hall.Data;
using Events_Hall.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events_Hall.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _db;

        [ActivatorUtilitiesConstructor]
        public EventsController(ApplicationDbContext context)
        {
            _db = context;
        }

        public EventsController()
        {
        }

        public IActionResult Index()
        {
            var DbEvents = _db.Events.ToList();
            ViewBag.Events = DbEvents;
            return View();
        }
        public IActionResult Details(int? id)
        {
            var detail = _db.Events.ToList().Find(p => p.Id == id);
            if (detail == null)
            {
                return View("_NotFound");
            }
            ViewData["detail"] = detail;
            return View("Details");
        }

        public IActionResult Details1(int? id)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDB").Options;
            var db = new ApplicationDbContext(options);
            var detail = db.Events.ToList().Find(p => p.Id == id);
            if (detail == null)
            {
                return View("_NotFound");
            }
            ViewData["detail"] = detail;
            return View("Details");
        }
        [Authorize]
        public IActionResult Dashboard()
        {
            var DbEvents = _db.Events.ToList();
            ViewBag.Events = DbEvents;
            return View("Dashboard");
        }

        public IActionResult Register(int? id)
        {
            var EventId = id;
            ViewData["EventId"] = EventId;
            return View();
        }
        
        [HttpPost]
        public IActionResult Register([Bind("Name", "Email", "Phone", "Field", "EventId")] AttendeeModel attendee)
        {
            if (ModelState.IsValid)
            {
                _db.Attendees.Add(attendee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Register");
        }

        [Authorize]
        public IActionResult Create()
        {

            return View("Create");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create([Bind("Name", "Description", "Time", "Duration", "Image", "HallId", "PresentorId", "PresentorName")] EventModel eventt)
        {
            if (ModelState.IsValid)
            {
                _db.Events.Add(eventt);
                _db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return RedirectToAction("Create");
        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
            var Event = _db.Events.ToList().Find(p => p.Id == id);
            if (id == null || Event == null)
            {
                return View("_NotFound");
            }
            ViewData["Event"] = Event;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Description", "Time", "Duration", "Image", "HallId", "PresentorId", "PresentorName")] EventModel eventt)
        {
            _db.Events.Update(eventt);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Event = _db.Events.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Event == null)
            {
                return View("_NotFound");
            }
            _db.Events.Remove(Event);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
    }


