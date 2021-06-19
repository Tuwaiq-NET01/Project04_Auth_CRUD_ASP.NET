using System;
using System.Linq;
using AppStore.Data;
using AppStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Controllers
{
    [Authorize]
    public class RatingsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public RatingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create(int? id , /*This Parameter Added For Unit Testing :( */string fakeId = "") // Receive App Id
        {
            var App = _db.Apps.ToList().Find(a => a.Id == id);
            if (App == null)
            {
                return View("_NotFound");
            }
            
            // This Code Added For Unit Test :(
            if (!String.IsNullOrEmpty(fakeId))
            {
                var ratingTest = _db.Ratings.Where(a => a.AppId == id).ToList()
                    .Find(u => u.UserId == fakeId);
                if (ratingTest != null)
                {
                    return RedirectToAction("Edit", new {ratingTest.Id});
                }
                ViewBag.App = App;
                return View();
            }
            
            // Redirect To Edit Review If Already User Reviewed App
            var rating = _db.Ratings.Where(a => a.AppId == id).ToList()
                .Find(u => u.UserId == _userManager.GetUserId(User));
            if (rating != null)
            {
                return RedirectToAction("Edit", new {rating.Id});
            }

            ViewBag.App = App;
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Rating", "Review")] RatingModel ratingModel, int appid)
        {
            if (ModelState.IsValid)
            {
                // Change App Rating After Posting New Rating
                // var app = _db.Ratings.Where(a => a.AppId == appid).ToList();
                // var appAvgRating = app.Average(a => a.Rating) + ratingModel.Rating / (app.Count() + 1);
                // _db.Apps.ToList().Find(a => a.Id == appid).AverageRating = appAvgRating;
                UpdateAvgRating(appid, ratingModel.Rating);

                ratingModel.UserId = _userManager.GetUserId(User);
                ratingModel.AppId = appid;
                ratingModel.ReviewDate = DateTime.Now;
                _db.Ratings.Add(ratingModel);
                _db.SaveChanges();
                return RedirectToAction("Details", "Apps", new {id = appid});
            }

            return RedirectToAction("Create", new {id = appid});
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var review = _db.Ratings
                .Include(a => a.App)
                .ToList().Find(r => r.Id == id);
            if (id == null || review == null)
            {
                return View("_NotFound");
            }

            return View(review);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id", "Rating", "Review", "AppId", "UserId")]
            RatingModel ratingModel)
        {
            if (ModelState.IsValid)
            {
                ratingModel.UserId = _userManager.GetUserId(User);
                ratingModel.ReviewDate = DateTime.Now;
                _db.Ratings.Update(ratingModel);

                var oldRating = _db.Ratings
                    .Where(u=>u.UserId == ratingModel.UserId)
                    .ToList()
                    .Find(r => r.AppId == ratingModel.AppId);
                UpdateAvgRating(ratingModel.AppId, ratingModel.Rating, oldRating.Rating);

                _db.SaveChanges();
                return RedirectToAction("Details", "Apps", new {id = ratingModel.AppId});
            }

            return RedirectToAction("Edit", new {id = ratingModel.Id});
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var rating = _db.Ratings.ToList().Find(r => r.Id == id);
            if (id == null || rating == null)
            {
                return View("_NotFound");
            }

            UpdateAvgRating(rating.AppId, rating.Rating, delete: true);
            _db.Ratings.Remove(rating);
            _db.SaveChanges();
            return RedirectToAction("Details", "Apps", new {id = rating.AppId});
        }

        private void UpdateAvgRating(int AppId, float Rating, float oldRating = -1, bool delete = false)
        {
            var app = _db.Ratings.Where(a => a.AppId == AppId).ToList();

            if (delete)
            {
                if (app.Count>1) // Update Avg if review deleted
                { 
                    _db.Apps.ToList().Find(a => a.Id == AppId).AverageRating =
                        (app.Sum(a => a.Rating) - Rating) / ((app.Count() - 1));
                }
                else // if last Review deleted
                {
                    _db.Apps.ToList().Find(a => a.Id == AppId).AverageRating = 0;
                }
                return;
            }
            if (app.Count > 0)
            {
                if (oldRating == -1) // New Review 
                {
                    var appAvgRating = (app.Sum(a => a.Rating) + Rating) / (app.Count() + 1);
                    _db.Apps.ToList().Find(a => a.Id == AppId).AverageRating = appAvgRating;
                }
                else // Edit Review
                {
                    var appAvgRating = (app.Sum(a => a.Rating) + Math.Abs(Rating - oldRating)) / (app.Count());
                    _db.Apps.ToList().Find(a => a.Id == AppId).AverageRating = appAvgRating;
                }
            }
            else // New First Review 
            {
                _db.Apps.ToList().Find(a => a.Id == AppId).AverageRating = Rating;
            }
        }
    }
}