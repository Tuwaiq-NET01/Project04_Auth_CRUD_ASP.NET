using Final_project.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Microsoft.AspNetCore.Authorization;

namespace Final_project.Controllers
{
    [AllowAnonymous]
    public class LoginAdmin : Controller
    {
        private ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public LoginAdmin(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager, ApplicationDbContext db)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            _db = db;
        }

    
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminModel admin)
        {
           bool result = _db.Admins.Any(x => x.Email  == admin.Email &&  x.Password == admin.Password);
         
            if (result)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "invalid Password or Email");
            }
           
           
            return View();
        }

    }
}
