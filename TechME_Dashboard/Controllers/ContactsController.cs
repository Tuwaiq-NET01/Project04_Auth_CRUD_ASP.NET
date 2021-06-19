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
    [Authorize(Roles = "User")]

    public class ContactsController : Controller
    {
         

            private readonly TechMEDbContext _db;

            public ContactsController(TechMEDbContext context)
            {
                _db = context;
            }
        [Authorize]

        public IActionResult Index(int ID = 1) // هل لازم  زم يكون فية Id او لا
        {
            var Contact = _db.ContactUs.ToList();
            ViewData["Contact"] = Contact;
            ViewData["ID"] = ID;

            return View();
        }

        // GET: course/ID
        [Authorize]

        [HttpGet]
        public IActionResult Details(int? ID)
        {
            var Contact = _db.ContactUs.ToList().Find(Contact => Contact.Contact_ID == ID);
            if (ID == null || Contact == null)
            {
                return View("_NotFound");
            }
            ViewData["Contact"] = Contact;
            return View(Contact);

        }
        // Create
        //GET - /Contacts/create
        [AllowAnonymous]

        public IActionResult Create()
            {
                return View();
            }

            //POST - /Contactus/create
            [HttpPost]
        [AllowAnonymous]

        public IActionResult Create([Bind("Sender_Name", " Sender_Email", "Masssege_Subject", "Sender_Massege")] ContactModel Contact)
            {
                if (ModelState.IsValid) //check the state of model
                {
                    _db.ContactUs.Add(Contact);
                    _db.SaveChanges();

                }
            return RedirectToAction("Index");
/*            return View(Contact);
*/            }


        //GEt - /Courses/edit/id
        [Authorize]

        public IActionResult Edit(int? ID)
        {
            var Contact = _db.ContactUs.ToList().Find(E => E.Contact_ID == ID);
            if (ID == null || Contact == null)
            {
                return View("_NotFound");
            }
            ViewData["Contact"] = Contact;
            return View();
        }
        //POST - /Courses/edit/id
        [HttpPost]
        [Authorize]

        public IActionResult Edit( int ID, [Bind("Contact_ID","Sender_Name", " Sender_Email", "Masssege_Subject", "Sender_Massege")] ContactModel Contact)
        {
            _db.ContactUs.Update(Contact);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST - /Course/delete/id
        [HttpPost]
        [Authorize]

        public IActionResult Delete(int ID)
        {
            var Contact = _db.ContactUs.ToList().FirstOrDefault(C => C.Contact_ID == ID);
            _db.ContactUs.Remove(Contact);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}
