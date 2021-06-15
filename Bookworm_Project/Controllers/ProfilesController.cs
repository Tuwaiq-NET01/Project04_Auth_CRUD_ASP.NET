using Bookworm_Project.Data;
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
            return View();
        }

        public async Task<IActionResult> MeAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            var reviews = _db.Reviews.Where(r=>r.UserId==user.Id).Include(r=>r.Book).ToList();
            var UserWithData = _db.Users.FirstOrDefault(u=>u.Id==user.Id);
            ViewBag.User = user;
            return View();
        }


    }
}
