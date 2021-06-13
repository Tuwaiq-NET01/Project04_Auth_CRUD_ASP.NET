using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Authorize]
    public class DropsController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<IdentityUser> userManager;

        public DropsController(ApplicationDbContext applicationDbContext, UserManager<IdentityUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewData["Records"] = applicationDbContext.Drops.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            DropViewModel model = new DropViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DropViewModel model)
        {
            if(ModelState.IsValid)
            {
                await applicationDbContext.Drops.AddAsync(new Drop
                {
                    UserId = userManager.GetUserId(User),
                    Content = model.Content
                });
                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
