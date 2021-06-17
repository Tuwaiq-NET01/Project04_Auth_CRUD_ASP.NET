using Bookworm_Project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bookworm_Project.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public ProfilesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var DbUsers = _db.Users.ToList();
            ViewBag.Users = DbUsers;
            return View();
        }

        public IActionResult Search(string query)
        {
            var DbUsers = _db.Users.Where(u => u.FirstName.Contains(query) || u.LastName.Contains(query) ).ToList();
            ViewBag.Users = DbUsers;
            return View("Index");
        }

        [Authorize]
        public async Task<IActionResult> MeAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            var reviews = _db.Reviews.Where(r=>r.UserId==user.Id).Include(r=>r.Book).ToList();
            var UserWithData = _db.Users.FirstOrDefault(u=>u.Id==user.Id);
            ViewBag.User = user;
            return View();
        }

        // GET: /books/:id  
        public async Task<IActionResult> ShowAsync(string Id)
        {
            
            var user = _db.Users
                .Include(u=>u.Reviews)
                .ThenInclude(r=>r.Book)
                .Single(u => u.Id == Id);

            if (Id == null || user == null)
            {
                return View("_NotFound");
            }
            ViewBag.User = user;
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                if (currentUser.Id == user.Id) return View("Me");
                return View();
            }
            return View();
        }


    }
}
