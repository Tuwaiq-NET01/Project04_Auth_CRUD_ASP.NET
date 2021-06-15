using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Final.Models;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Data;

namespace MVC_Final.Controllers
{
    public class UserController : Controller
    {

        private readonly LibraryContext _db;

        public UserController(LibraryContext context)
        {
            _db = context;
        }

        public IActionResult User()
        {
            var user = _db.Users.ToList();
            var books = _db.Books.ToList();

            ViewData["users"] = user;
            ViewData["books"] = books;
            return View();
        }

        //Get - path: Publisher/Create
        public IActionResult Create()
        {
            return View();
        }

        //Post - path: Publisher/Create
        [HttpPost]
        public IActionResult Create([Bind] User user) // Bind with Publisher model
        {
            if (ModelState.IsValid)// check the state of the model
            {
                _db.users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("User");
            }
            return View(user);
        }

       /* //Update - path: Publisher/Edit
        public IActionResult Edit(int id)
        {
            var publisher = _db.Publishers.ToList().Find(p => p.Id == id);
            if (id == null || publisher == null)
            {
                return RedirectToAction("Publisher");
            }
            ViewData["publishers"] = publisher;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Name", "Address")] Publisher publishr)
        {
            var publisher = _db.Publishers.ToList().Find(p => p.Id == id);
            publisher.Name = publishr.Name;
            publisher.Address = publishr.Address;
            _db.Publishers.Update(publisher);
            _db.SaveChanges();
            return RedirectToAction("Publisher");
        }
*/
        //Delete - path: Publisher/Delete
        public IActionResult Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            _db.Users.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("User");
        }

    }
}
