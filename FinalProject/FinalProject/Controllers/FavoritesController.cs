using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public FavoritesController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Records"] = applicationDbContext.FavoriteDrops.ToList();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> MarkAsFavorite(int dropId, string userId)
        {
            var alreadyExists = applicationDbContext.FavoriteDrops.Where(e => e.ApplicationUserId == userId && e.DropId == dropId).Include(e=>e.ApplicationUser).Include(e=>e.Drop).FirstOrDefault();
            if (alreadyExists != null) return RedirectToAction("Index", "Drops");

            var fd = new FavoriteDrop()
            {
                ApplicationUserId = userId,
                DropId = dropId,
                ApplicationUser=alreadyExists.ApplicationUser,
                Drop = alreadyExists.Drop
            };

            await applicationDbContext.FavoriteDrops.AddAsync(fd);
            await applicationDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Drops");
        }

    }
}
