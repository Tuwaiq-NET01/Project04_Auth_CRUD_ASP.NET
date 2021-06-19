using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    /*[ApiController]
    [Route("[controller]")]*/
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<IdentityUser> _userManager;
        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> UserManager)
        {
            _userManager = UserManager;
            _db = context;
        }
        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (_db.Profiles.Any(o => o.UserId == _userManager.GetUserId(User)))
            {
            return View();
            }
                return Redirect("/Profile");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        /*public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<ChatModel>> CreateChat([Bind("Id", "To", "UserId")] ChatModel chat)
        {
            //if (ModelState.IsValid)
            //{
                await _db.Chats.AddAsync(chat);
                await _db.SaveChangesAsync();
                *//*_db.Chats.Add(chat);
                _db.SaveChanges();*//*
                //return RedirectToAction("Index");
            //}
            return Ok(chat);

        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
