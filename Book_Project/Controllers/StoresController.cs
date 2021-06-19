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
    public class StoresController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StoresController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IQueryable<BookStoreModel> stores = _db.BookStores
                .OrderBy(a => a.Id)
                .Include(a => a.BookStores_Books);



            return View(stores.ToList());
        }


        //GET - /Stores/Add
        public IActionResult Add()
        {

            return View("Add");
        }

        //POST - /Stores/Add
        [HttpPost]
        public IActionResult Add([Bind("Id", "Name")] BookStoreModel store)
        {
            //Another way for bind the data posted to database
            /*_db.Books.Add(new BookModel() {Id=book.Id ,Name=book.Name,Image=book.Image,Description=book.Description,
            AuthorId=book.AuthorId,PublisherId=book.PublisherId
            });*/


            if (ModelState.IsValid)
            {
                _db.BookStores.Add(store);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        //GET - Stores/Edit/id
        public IActionResult Edit(int? Id)
        {
            var StoreResult = _db.BookStores.ToList().Find(a => a.Id == Id);
            if (Id == null || StoreResult == null)
            {
                return View("_NotFound");
            }

            ViewData["StoreResult"] = StoreResult;

            return View();
        }


        //POST - Stores/Edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name")] BookStoreModel store)
        {
            _db.BookStores.Update(store);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        //Post - Stores/Delete/id
        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            var StoreResult = _db.BookStores.ToList().Find(a => a.Id == Id);
            if (Id == null || StoreResult == null)
            {
                return View("_NotFound");
            }

            _db.BookStores.Remove(StoreResult);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
