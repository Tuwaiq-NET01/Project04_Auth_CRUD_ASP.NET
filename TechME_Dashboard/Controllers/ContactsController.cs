using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechME_Dashboard.Data;
using TechME_Dashboard.Models;


namespace TechME_Dashboard.Controllers
{
    public class ContactsController : Controller
    {
         

            private readonly TechMEDbContext _db;

            public ContactsController(TechMEDbContext context)
            {
                _db = context;
            }
            // Create
            //GET - /Contacts/create
            public IActionResult Create()
            {
                return View();
            }

            //POST - /Contactus/create
            [HttpPost]
            public IActionResult Create([Bind("Contact_ID", "Sender_Name", " Sender_Email ", "Message_Subject", "Sender_Massage")] ContactModel Contact)
            {
                if (ModelState.IsValid) //check the state of model
                {
                    _db.ContactUs.Add(Contact);
                    _db.SaveChanges();
                    return RedirectToAction("Create");
                }
                ViewData["Contact"] = Contact;
                return View(Contact);
            }
        }
    
}
