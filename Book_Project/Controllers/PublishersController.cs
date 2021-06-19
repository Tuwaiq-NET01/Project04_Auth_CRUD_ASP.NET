using Book_Project.Data;
using Book_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Project.Controllers
{
    public class PublishersController : Controller
    {

        private readonly ApplicationDbContext _db;

        public PublishersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IQueryable<PublisherModel> publishers = _db.Publishers
                .OrderBy(a => a.Id)
                .Include(a => a.Books);



            return View(publishers.ToList());
        }

        //GET - /Publishers/Add
        public IActionResult Add()
        {

            return View("Add");
        }

        //POST - /Publishers/Add
        [HttpPost]
        public IActionResult Add([Bind("Id", "Name")] PublisherModel publisher)
        {
            //Another way for bind the data posted to database
            /*_db.Books.Add(new BookModel() {Id=book.Id ,Name=book.Name,Image=book.Image,Description=book.Description,
            AuthorId=book.AuthorId,PublisherId=book.PublisherId
            });*/


            if (ModelState.IsValid)
            {
                _db.Publishers.Add(publisher);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        //GET - Publishers/Edit/id
        public IActionResult Edit(int? Id)
        {
            var PublisherResult = _db.Publishers.ToList().Find(a => a.Id == Id);
            if (Id == null || PublisherResult == null)
            {
                return View("_NotFound");
            }

            ViewData["PublisherResult"] = PublisherResult;

            return View();
        }


        //POST - Publishers/Edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name")] PublisherModel publisher)
        {
            _db.Publishers.Update(publisher);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        //Post - Publishers/Delete/id
        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            var PublisherResult = _db.Publishers.ToList().Find(a => a.Id == Id);
            if (Id == null || PublisherResult == null)
            {
                return View("_NotFound");
            }

            _db.Publishers.Remove(PublisherResult);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
