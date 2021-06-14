using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<ApplicationUser> userManager;

        public DropsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var list = applicationDbContext.Drops.Include(f=>f.ApplicationUser).ToList();

            //for (int i = 0; i < list.Count; i++)
            //{
            //    var r = await userManager.FindByIdAsync(list[i].IdentityUserId);
            //    list[i].IdentityUser = r;
            //}
            ViewData["Records"] = list;
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
            if (ModelState.IsValid)
            {
                await applicationDbContext.Drops.AddAsync(new Drop
                {
                    ApplicationUserId = userManager.GetUserId(User),
                    Content = model.Content
                });
                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var drop = await applicationDbContext.Drops.FirstOrDefaultAsync(d => d.Id == id);
            if (drop == null) return NotFound();

            DropViewModel dropModel = new DropViewModel();
            dropModel.UserId = drop.ApplicationUserId;
            dropModel.User = drop.ApplicationUser;
            dropModel.Content = drop.Content;

            return View(dropModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var drop = await applicationDbContext.Drops.FirstOrDefaultAsync(d => d.Id == id);
            if (drop == null) return NotFound();

            DropViewModel model = new DropViewModel()
            {
                UserId=drop.ApplicationUserId,
                Content=drop.Content,
                User=drop.ApplicationUser
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DropViewModel model)
        {
            var drop = await applicationDbContext.Drops.FirstOrDefaultAsync(d => d.Id == id);
            if (drop == null) return NotFound();

            if (ModelState.IsValid)
            {
                drop.Content = model.Content;
                //await applicationDbContext.Drops.AddAsync(drop);
                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var drop = await applicationDbContext.Drops.FirstOrDefaultAsync(d => d.Id == id);
            if (drop == null) return NotFound();

            if (ModelState.IsValid)
            {
                //drop.Content = model.Content;
                //await applicationDbContext.Drops.AddAsync(drop);
                applicationDbContext.Remove(drop);
                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
