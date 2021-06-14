using Microsoft.AspNetCore.Mvc;
using MVC_Final.Data;
using MVC_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Final.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryContext _db;

        public AuthorController(LibraryContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Author()
        {
            var Authors = _db.Authors.ToList();

            ViewData["authors"] = Authors;
            return View();
        }

        public IActionResult Details(int id)
        {
            var author = _db.Authors.ToList().Find(a => a.Id == id);

            if (author == null)
            {
                return Content("ii");
            }

            ViewData["authors"] = author;
            return View(author);
        }

        //Get - path: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        //Post - path: Book/Create
        [HttpPost]
        public IActionResult Create([Bind("Name")] Author authorI) // Bind with product model
        {
            if (ModelState.IsValid)// check the state of the model
            {
                _db.Authors.Add(authorI);
                _db.SaveChanges();
                return RedirectToAction("author");
            }
            return View(authorI);
        }

        public IActionResult Edit(int id)
        {
            var author = _db.Authors.ToList().Find(a=>a.Id == id);
            if (id == 0 || author == null)
            {
                return RedirectToAction("Author");
            }
            ViewData["Authors"] = author;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Name")] Author authorI)
        {
            var author = _db.Authors.ToList().Find(a => a.Id == id);
            author.Name = authorI.Name;
            _db.Authors.Update(author);
            _db.SaveChanges();
            return RedirectToAction("Author");
        }


        public IActionResult Delete(int id)
        {
            var author = _db.Authors.FirstOrDefault(a => a.Id == id);
            _db.Authors.Remove(author);
            _db.SaveChanges();
            return RedirectToAction("Author");
        }
    }
}
