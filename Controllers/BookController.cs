using MVC_Final.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Final.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace MVC_Final.Controllers
{
    public class BookController : Controller
    {

        //
        private readonly LibraryContext _db;

        public BookController(LibraryContext context)
        {
            _db = context;

        }


        public IActionResult Book()
        {
            var books = _db.Books.ToList();
            var authors = new List<Author>();
            var publishers = new List<Publisher>();
            foreach (var book in books)
            {
                authors.Add(_db.Authors.Find(book.AuthorId));
                publishers.Add(_db.Publishers.Find(book.PublisherId));
            }

            ViewData["books"] = books;
            ViewData["authors"] = authors;
            ViewData["publishers"] = publishers;
            return View();
        }

        public List<Book> getAllBooks()
        {
            List<Book> book = _db.Books.ToList();
            return book;
        }

        public IActionResult Details(int id)
        {
            var book = _db.Books.ToList().Find(B => B.Id == id);
            var author = _db.Authors.ToList();
            var publisher = _db.Publishers.ToList();


            if (book == null)
            {
                return Content("ii");
            }
            ViewData["publisher"] = publisher;
            ViewData["author"] = author;
            ViewData["books"] = book;
            return View(book);
        }

        //Get - path: Book/Create
        public IActionResult Create()
        {
            var authorId = _db.Books.ToList();
            ViewData["books"] = authorId;
            return View();
        }

        public void createBook( Book book)
        {
            if (ModelState.IsValid)// check the state of the model
            {
                _db.Books.Add(book);
                _db.SaveChanges();
            } 
        }

        //Post - path: Book/Create
        [HttpPost]
        public IActionResult Create([Bind("Title", "Availabe", "Price", "AuthorId", "PublisherId")] Book bookItem) // Bind with product model
        {
            if (ModelState.IsValid) // check the state of the model
            {
                createBook(bookItem);
                return RedirectToAction("Book");
            }
            return View(bookItem);
        }


        public IActionResult Edit(int id)
        {
            var book = _db.Books.ToList().Find(p => p.Id == id);
            if (id == null || book == null)
            {
                return RedirectToAction("Book");
            }
            ViewData["Books"] = book;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Title", "Availabe", "Price", "AuthorId")] Book bookItem)
        {
            var Book = _db.Books.ToList().Find(p => p.Id == id);
            Book.Title = bookItem.Title;
            Book.Price = bookItem.Price;
            Book.Availabe = bookItem.Availabe;
            _db.Books.Update(Book);
            _db.SaveChanges();
            return RedirectToAction("Book");
        }


        public IActionResult Delete(int id)
        {
            var book = _db.Books.FirstOrDefault(p => p.Id == id);
            _db.Books.Remove(book);
            _db.SaveChanges();
            return RedirectToAction("Book");
        }

    }
}

