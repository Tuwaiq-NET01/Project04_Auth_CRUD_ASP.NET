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
    public class PublisherController : Controller
    {

        private readonly LibraryContext _db;

        public PublisherController(LibraryContext context)
        {
            _db = context;
        }

        public IActionResult Publisher()
        {
            var publisher = _db.Publishers.ToList();
            //var books = _db.Books.Include(book => book.PIdNavigation).ThenInclude(p => p.Name).Include(book => book.Title).ToList();

            //ViewData["books"] = books;
            ViewData["publishers"] = publisher;
            return View();
        }

        public IActionResult Details(int id)
        {
            var publisher = _db.Publishers.ToList().Find(P => P.Id == id);

            if (publisher == null)
            {
                return Content("ii");
            }

            ViewData["publishers"] = publisher;
            return View(publisher);
        }

        public IActionResult BooksList(int id)
        {
            return View();
        }

        //Get - path: Publisher/Create
        public IActionResult Create()
        {
            return View();
        }

        //Post - path: Publisher/Create
        [HttpPost]
        public IActionResult Create([Bind("Name", "Address")] Publisher publisher) // Bind with Publisher model
        {
            if (ModelState.IsValid)// check the state of the model
            {
                _db.Publishers.Add(publisher);
                _db.SaveChanges();
                return RedirectToAction("publisher");
            }
            return View(publisher);
        }

        //Update - path: Publisher/Edit
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

        //Delete - path: Publisher/Delete
        public IActionResult Delete(int id)
        {
            var publisher = _db.Publishers.FirstOrDefault(p => p.Id == id);
            _db.Publishers.Remove(publisher);
            _db.SaveChanges();
            return RedirectToAction("Publisher");
        }

    }
}
