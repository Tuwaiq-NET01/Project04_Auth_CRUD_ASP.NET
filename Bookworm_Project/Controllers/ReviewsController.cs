using Bookworm_Project.Data;
using Bookworm_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookworm_Project.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public ReviewsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        // POST: /reviews/add
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAsync([Bind("Content, BookId")] ReviewModel review,int Id)
        {
            var user = await _userManager.GetUserAsync(User);
            review.UserId = user.Id;
            review.BookId = Id;

            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
            }
            return RedirectToAction("Details", "Books", new { Id });
            
        }

        // POST: /authors/delete/id
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? Id,int BookId)
        {

            var Review = _db.Reviews.ToList().Find(r => r.Id == Id);
            if (Id == null || Review == null)
            {
                return View("_NotFound");
            }
            else
            {
                _db.Reviews.Remove(Review);
                _db.SaveChanges();
                return RedirectToAction("Details", "Books", new { Id=BookId });
            }

        }

    }
}
