using Bookworm_Project.Data;
using Bookworm_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookworm_Project.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        // GET: /books
        public async Task<IActionResult> IndexAsync()
        {
            
            var user = await _userManager.GetUserAsync(User);
            var DbBooks = _db.Books.Include(b=>b.Author).ToList();
            ViewBag.Books = DbBooks;
            if(user!=null) ViewBag.CurrentUser = user.Id;
            else ViewBag.CurrentUser = "none";

            return View();
        }
        public async Task<IActionResult> SearchAsync(string query)
        {
            var user = await _userManager.GetUserAsync(User);
            var DbBooks = _db.Books.Where(b => b.Title.Contains(query) || b.Author.FirstName.Contains(query) || b.Author.LastName.Contains(query)).Include(b => b.Author).ToList();
            ViewBag.Books = DbBooks;
            if (user != null) ViewBag.CurrentUser = user.Id;
            else ViewBag.CurrentUser = "none";
            return View("Index");
        }

        // GET: /books/:id  
        public async Task<IActionResult> DetailsAsync(int? Id)
        {
            var user = await _userManager.GetUserAsync(User);
            var Book = _db.Books.Include(b=>b.Author).Include(b => b.Reviews)
                .ThenInclude(r => r.User)
                .Single(b => b.Id == Id);

            if (Id == null || Book == null)
            {
                return View("_NotFound");
            }
            ViewBag.Book = Book;
            if (user != null) ViewBag.CurrentUser = user.Id;
            else ViewBag.CurrentUser = "none";
            return View();
        }

        [Authorize]
        // GET: /books/create
        public IActionResult Create()
        {
            return View();

        }

        // POST: /books/create
        [Authorize]
        [HttpPost]
        public IActionResult Create([Bind("AuthorId", "Title", "Description", "Cover")] BookModel book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);

        }

        // GET: /books/edit/id
        [Authorize]
        public IActionResult Edit(int? Id)
        {

            var Book = _db.Books.ToList().Find(b => b.Id == Id);
            if (Id == null || Book == null)
            {
                return View("_NotFound");
            }

            return View(Book);

        }

        // POST: /books/edit/id
        [Authorize]
        [HttpPost]
        public IActionResult Edit([Bind("Id","AuthorId", "Title", "Description", "Cover")] BookModel book)
        {

            _db.Books.Update(book);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        // POST: /books/delete/id
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? Id)
        {

            var Book = _db.Books.ToList().Find(b => b.Id == Id);
            if (Id == null || Book == null)
            {
                return View("_NotFound");
            }
            else
            {
                _db.Books.Remove(Book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}
