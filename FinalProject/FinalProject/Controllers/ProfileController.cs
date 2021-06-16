using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProfileController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public List<ProfileModel> Get()
        {
            return _db.Profiles.Where(s => s.Id < 44).ToList();
        }
        [HttpPost]
        public async Task<ActionResult<ProfileModel>> CreateProfile([Bind("Id", "PhoneNomber", "DisplayName", "Image", "LastSeen", "UserId")] ProfileModel prof)
        {
            //if (ModelState.IsValid)
            //{
            if (!_db.Profiles.Any(o => o.UserId == prof.UserId))
            {

                await _db.Profiles.AddAsync(prof);
                await _db.SaveChangesAsync();
                return Ok("Added");
            }
            
            /*_db.Chats.Add(chat);
            _db.SaveChanges();*/
            //return RedirectToAction("Index");
            //}
            return Ok("Already added");

        }
    }
}
