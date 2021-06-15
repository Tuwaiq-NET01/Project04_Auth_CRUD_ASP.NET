using HjtProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var Profile = _db.UserProfiles.FirstOrDefault(u => u.Id == userId.Value);
            ViewData["Profile"] = Profile;

            return View();
        }
    }
}
