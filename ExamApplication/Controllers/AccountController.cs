using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExamApplication.Data;
using ExamApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Controllers
{
    public class AccountController : Controller
    {
        private MyDbContext _db = new MyDbContext();
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admins admin)
        {
            bool result = _db.Admin.Any(x => x.userName == admin.userName && x.password == admin.password);
            if (result)
            {
                return RedirectToAction("../Questions/Index");
            }
            else
            {
                ModelState.AddModelError("", "invalid username or password");
            }
            return View();
        }

        public IActionResult loginAsStudents()
        {
            return View();
        }
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult loginAsStudents(Students st)
        {
            bool result = _db.Student.Any(x => x.userName == st.userName && x.password == st.password);
            if (result)
            {
                return RedirectToAction("../Exam/Index");
            }
            else
            {
                ModelState.AddModelError("", "invalid username or password");
            }
            return View();
        }
        
      


    }
}
