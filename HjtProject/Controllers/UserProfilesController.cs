using HjtProject.Data;
using HjtProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HjtProject.Controllers
{
    [Authorize]
    public class UserProfilesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserProfilesController(ApplicationDbContext db)
        {
            _db = db;
        }
            public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            var Profile = _db.UserProfiles.Include(c=>c.Course).FirstOrDefault(u => u.Id == userId.Value); // include is like a join with the navigation
            ViewData["Profile"] = Profile;


            return View();
        }
        // Post - /instructors/delete/id
        [HttpPost]
        public IActionResult Enroll(int? id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            var Profile = _db.UserProfiles.FirstOrDefault(u => u.Id == userId.Value);

            var course = _db.Courses.ToList().Find(p => p.Id == id);
            Profile.CourseId = course.Id;

         
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public Boolean Check_if_in_database(string? id)
        {
            var user1 = _db.UserProfiles.FirstOrDefault(p => p.Id == id);

            if (id == null || user1 == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
