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
    public class TagsController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public TagsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var list = applicationDbContext.Tags.ToList();
            ViewData["Records"] = list;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            TagViewModel model = new TagViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                await applicationDbContext.Tags.AddAsync(new Tag
                {
                    Title =  model.Title
                });
                await applicationDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> View(int id)
        //{
        //    var drop = await applicationDbContext.Drops.FirstOrDefaultAsync(d => d.Id == id);
        //    if (drop == null) return NotFound();

        //    DropViewModel dropModel = new DropViewModel();
        //    dropModel.UserId = drop.ApplicationUserId;
        //    dropModel.User = drop.ApplicationUser;
        //    dropModel.Content = drop.Content;

        //    return View(dropModel);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var drop = await applicationDbContext.Drops.FirstOrDefaultAsync(d => d.Id == id);
        //    if (drop == null) return NotFound();

        //    DropViewModel model = new DropViewModel()
        //    {
        //        UserId = drop.ApplicationUserId,
        //        Content = drop.Content,
        //        User = drop.ApplicationUser
        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, DropViewModel model)
        //{
        //    var drop = await applicationDbContext.Drops.FirstOrDefaultAsync(d => d.Id == id);
        //    if (drop == null) return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        drop.Content = model.Content;
        //        //await applicationDbContext.Drops.AddAsync(drop);
        //        await applicationDbContext.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var drop = await applicationDbContext.Drops.FirstOrDefaultAsync(d => d.Id == id);
        //    if (drop == null) return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        //drop.Content = model.Content;
        //        //await applicationDbContext.Drops.AddAsync(drop);
        //        applicationDbContext.Remove(drop);
        //        await applicationDbContext.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
}
