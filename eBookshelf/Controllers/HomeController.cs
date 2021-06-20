using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eBookshelf.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using eBookshelf.Data;
using System.Security.Claims;

namespace eBookshelf.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly UserManager<ApplicationUser> _manager;


        public HomeController(ILogger<HomeController> logger)//, UserManager<ApplicationUser> manager
        {
            _logger = logger;
           // _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Only Authenticated users can access thier profile
        [Authorize]
        public ActionResult Profile()
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Email);

            ViewBag.userId = userId;
            ViewBag.username = userName;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public Boolean Check_Minus(int? id)
        {
            if (id < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
