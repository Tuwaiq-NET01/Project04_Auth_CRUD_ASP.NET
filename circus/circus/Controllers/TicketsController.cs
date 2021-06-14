using circus.Data;
using circus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace circus.Controllers
{
    public class TicketsController : Controller
    {

        private readonly ApplicationDbContext _db;
        public TicketsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["tickets"] = _db.Tickets.ToList();
                ViewData["shows"] = _db.Shows.ToList();
                return View();
            }
            else
                return Redirect("~/Identity/Account/Login");

        }
        //GET - create
        public IActionResult Create(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["show"] = _db.Shows.ToList().Find(x => x.Id == id);
                ViewData["performers"] = _db.Performers.ToList();
                return View();
            }
            return Redirect("~/Identity/Account/Login");
        }
        //POST - create
        [HttpPost]
        public IActionResult Create([Bind("UserId","ShowId","Quantity")]TicketModel ticket)
        {
            if (ModelState.IsValid)
            {
                _db.Add(ticket);
                _db.SaveChanges();
            }
            return Redirect("~/shows/");
        }
    }
}
