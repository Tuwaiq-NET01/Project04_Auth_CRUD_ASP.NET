using FinalProjectMVC.Data;
using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMVC.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ContactsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View("Index");
        }
        // GET: /Contact/create
        public IActionResult Create()
        {
            return View();
        }

        //POST -/Contact/create 
        [HttpPost]
        public IActionResult Create([Bind("Name", "Email", "PhoneNo", "Massage")] ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Add(contact);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
/*
        [OneTimeSetUp]
        public IActionResult Create3([Bind("Name", "Email", "PhoneNo", "Massage")] ContactModel contact)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "ContactMassage").Options;
            var db = new ApplicationDbContext(options);
            *//*ContactModel contact = new ContactModel();*//*

            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                throw new ArgumentException("Invalid Model State");
            }
            }*/
        }
    }


