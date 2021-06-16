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
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        // GET: /Authors
        public async Task<IActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var DbAuthors = _db.Authors.ToList();
            ViewBag.Authors = DbAuthors;
            if (user != null) ViewBag.CurrentUser = user.Id;
            else ViewBag.CurrentUser = "none";
            return View();
        }

        public async Task<IActionResult> SearchAsync(string query)
        {
            var user = await _userManager.GetUserAsync(User);
            var DbAuthors = _db.Authors.Where(a => a.FirstName.Contains(query) || a.LastName.Contains(query)).ToList();
            ViewBag.Authors = DbAuthors;
            if (user != null) ViewBag.CurrentUser = user.Id;
            else ViewBag.CurrentUser = "none";
            return View("Index");
        }


        // GET: /authors/:id
        public IActionResult Details(int? Id)
        {

            var Author = _db.Authors.Include(a => a.Books).ThenInclude(b => b.Reviews)
                .Single(b => b.Id == Id);

            if (Id == null || Author == null)
            {
                return View("_NotFound");
            }
            ViewBag.Author = Author;
            return View(Author);
        }


        [Authorize]
        // GET: /authors/create
        public IActionResult Create()
        {
            return View();

        }

        // POST: /authors/create
        [Authorize]
        [HttpPost]
        public IActionResult Create([Bind("FirstName", "LastName", "Avatar", "Biography")] AuthorModel author)
        {
            if (ModelState.IsValid)
            {
                _db.Authors.Add(author);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);

        }


        // GET: /authors/edit/id
        [Authorize]
        public IActionResult Edit(int? Id)
        {

            var Author = _db.Authors.ToList().Find(a => a.Id == Id);
            if (Id == null || Author == null)
            {
                return View("_NotFound");
            }

            return View(Author);

        }

        // POST: /authors/edit/id
        [Authorize]
        [HttpPost]
        public IActionResult Edit([Bind("Id", "FirstName", "LastName", "Avatar", "Biography")] AuthorModel author)
        {

            _db.Authors.Update(author);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        // POST: /authors/delete/id
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? Id)
        {

            var Author = _db.Authors.ToList().Find(a => a.Id == Id);
            if (Id == null || Author == null)
            {
                return View("_NotFound");
            }
            else
            {
                _db.Authors.Remove(Author);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

        }


    }
}
