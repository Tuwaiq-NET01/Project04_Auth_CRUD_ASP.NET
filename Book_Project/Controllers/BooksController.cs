using Book_Project.Data;
using Book_Project.Models;
using Book_Project.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Project.Controllers
{
    public class BooksController : Controller
    {
       
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            

            IQueryable<BookModel> books = _db.Books
                 .OrderBy(a => a.Id)
                 .Include(a => a.Author);


            /*IQueryable<BookStore_Book_Model> books = _db.BookStores_Books
                .OrderBy(a => a.Book_ID)
                .Include(a => a.Book)
                .Include(a => a.Book.Author)
                .Include(a => a.Book.Publisher)
                .Include(a => a.BookStore);*/



            /* var Book_BookStores_List = from book in _db.Books
                                from store in _db.BookStores
                                select new
                                {
                                    BookName = book.Name,
                                    StoreName = store.Name
                                };*/



            return View(books.ToList());
        }

        //GET Books/Details/Id
        public IActionResult Details(int? id)
        {

            IQueryable<BookModel> book = _db.Books
                 .Include(a => a.Author)
                 .Include(a => a.Publisher);

            var BookResult = book.ToList().Find(b => b.Id == id);

            if (id == null || BookResult == null)
            {
                return View("_NotFound");
            }

            ViewData["BookResult"] = BookResult;

            return View();
        }




        //GET - /Books/Add
        public IActionResult Add()
        {
            
            return View("Add");
        }

        //POST - /Books/Add
        [HttpPost]
        public IActionResult Add([Bind("Id", "Name", "Image", "Description", "AuthorId", "PublisherId")] BookModel book)
        {
            //Another way for bind the data posted to database
            /*_db.Books.Add(new BookModel() {Id=book.Id ,Name=book.Name,Image=book.Image,Description=book.Description,
            AuthorId=book.AuthorId,PublisherId=book.PublisherId
            });*/


            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }



        //GET - Books/Edit/id
        public IActionResult Edit(int? Id)
        {
            var BookResult = _db.Books.ToList().Find(b => b.Id == Id);
            if (Id == null || BookResult == null)
            {
                return View("_NotFound");
            }

            ViewData["BookResult"] = BookResult;

            return View();
        }


        //POST - Books/Edit/id
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Name", "Image", "Description", "AuthorId", "PublisherId")]BookModel book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        //Post - Books/Delete/id
        [HttpPost]
        public IActionResult Delete(int? Id)
        {
            var BookResult = _db.Books.ToList().Find(b => b.Id == Id);
            if (Id == null || BookResult == null)
            {
                return View("_NotFound");
            }

            _db.Books.Remove(BookResult);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}
