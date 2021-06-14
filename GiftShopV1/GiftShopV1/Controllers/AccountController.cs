using GiftShopV1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GiftShopV1.Controllers
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
            return View(new LoginModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var Customer = new CustomerModel
            {
                CustomerId = 1,
                Username = "Yasmin",
                Password = "123",
                //Role = "Admin"
            };
            if (Customer == null)
                return Unauthorized();

            var claims = new List<Claim> //claims is a class 
            {
                new Claim(ClaimTypes.NameIdentifier, Customer.CustomerId.ToString()),
                new Claim(ClaimTypes.Name, Customer.Username),
                //new Claim(ClaimTypes.Role, user.Role),
                //new Claim("FavoriteColor", user.FavoriteColor)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
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
