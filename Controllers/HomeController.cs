using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MVC_Final.Models;
using MVC_Final.Data;

namespace MVC_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryContext _dbModel;

        public HomeController(ILogger<HomeController> logger, LibraryContext context)
        {
            _logger = logger;
            _dbModel = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //User login 
        //[HttpPost]
        public IActionResult Login(User user)
        {
            using (_dbModel)
            {
                var userDetails = _dbModel.Users.Where(info => info.UserName == user.UserName && info.Password == user.Password ).FirstOrDefault();
                if (userDetails == null)
                {

                    return View("Login", user);
                }
                else
                {
                    ViewData["userDetails"] = userDetails;
                    return View("Index");
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
