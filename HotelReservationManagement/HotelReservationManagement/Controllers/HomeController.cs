using HotelReservationManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManagement.Controllers
{
    public class HomeController : Controller
    {
       /* private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        private readonly UserManager<AdvanceUser> _userManager;
        public HomeController(UserManager<AdvanceUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //ViewBag.userid = _userManager.GetUserId(HttpContext.User);
            
           
            return View();
        }

        public IActionResult UserDetails()
        {
            var userid = _userManager.GetUserId(HttpContext.User);
            
            if (userid == null)
            {
                return RedirectToAction("_NotFound");
            }
            else
            {
                AdvanceUser user = _userManager.FindByIdAsync(userid).Result;
                ViewData["user"] = user;
                return View();
            }
            
            
        }

        
           
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
