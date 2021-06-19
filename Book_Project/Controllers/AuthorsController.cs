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
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IQueryable<AuthorModel> authors = _db.Authors
                 .OrderBy(a => a.Id)
                 .Include(a => a.Books);



            return View(authors.ToList());
        }


        //GET - /Authors/Add
        public IActionResult Add()
        {

            return View("Add");
        }

        //POST - /Authors/Add
        [HttpPost]
        public IActionResult Add([Bind("Id", "Name")] AuthorModel author)
        {
            //Another way for bind the data posted to database
            /*_db.Books.Add(new BookModel() {Id=book.Id ,Name=book.Name,Image=book.Image,Description=book.Description,
            AuthorId=book.AuthorId,PublisherId=book.PublisherId
            });*/


            if (ModelState.IsValid)
            {
                _db.Authors.Add(author);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }


         //GET - Authors/Edit/id
        public IActionResult Edit(int? Id)
        {
            var AuthorResult = _db.Authors.ToList().Find(a => a.Id == Id);
            if (Id == null || AuthorResult == null)
            {
                return View("_NotFound");
            }

            ViewData["AuthorResult"] = AuthorResult;

            return View();
        }


        //POST - Authors/Edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name")]AuthorModel author)
        {
            _db.Authors.Update(author);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        //Post - Authors/Delete/id
        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            var AuthorResult = _db.Authors.ToList().Find(a => a.Id == Id);
            if (Id == null || AuthorResult == null)
            {
                return View("_NotFound");
            }

            _db.Authors.Remove(AuthorResult);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
