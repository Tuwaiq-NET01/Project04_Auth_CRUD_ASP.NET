using Coffee.Areas.Identity.Pages.Account;
using Coffee.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Coffee.Controllers
{

    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new Login { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login model)
        {
            var user = new User
            {
                ID = 1,
                Name = "Albandry",
                Password = "123",
                Role = "Admin"
            };
            if (user == null)
                return Unauthorized();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
            };
            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = model.RememberLogin });
            return LocalRedirect(model.ReturnUrl);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
