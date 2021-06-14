using GiftShopV1.Data;
using GiftShopV1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShopV1.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Customers = _db.Customers.ToList();
            ViewData["Customers"] = Customers;
            return View();
        }
        public IActionResult Details(int? id)
        {
            var Customer = _db.Customers.ToList().Find(Customer => Customer.CustomerId == id);
            if (id == null || Customer == null)
            {
                return View("_NotFound");
            }
            ViewData["Customer"] = Customer;
            return View(Customer);

        }

        // GET  - /Customers/create
        public IActionResult Create()
        {
            return View();
        }
        // POST - /Customers/create
        [HttpPost] // Binding doesn't have to be in order
        public IActionResult Create([Bind("CustomerId", "FirstName", "LastName", "Username", "Email", "PhoneNumber", "Location")] CustomerModel Customer)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(Customer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        // GET  - /Customers/edit/id
        public IActionResult Edit(int id)
        {
            var Customer = _db.Customers.ToList().Find(p => p.CustomerId == id);
            if (id == null || Customer == null)
            {
                return View("_NotFound");
            }
            ViewData["Customer"] = Customer;
            return View();
        }
        // POST - /Customers/edit/id
        [HttpPost]
        public IActionResult Edit([Bind("CustomerId", "FirstName", "LastName", "Username", "Email", "PhoneNumber", "Location")] CustomerModel Customer)
        {
            _db.Customers.Update(Customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST - /Customers/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Customer = _db.Customers.ToList().Find(p => p.CustomerId == id);
            if (id == null || Customer == null)
            {
                return View("_NotFound");
            }
            _db.Customers.Remove(Customer);
            _db.SaveChanges();
            return RedirectToAction("Index"); // => /Customers
        }
    }
}
