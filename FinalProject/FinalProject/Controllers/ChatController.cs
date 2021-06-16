using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<IdentityUser> _userManager;
        public ChatController(ApplicationDbContext context, UserManager<IdentityUser> UserManager)
        {
            _userManager = UserManager;
            _db = context;
        }
        public IActionResult Index()
        {
            var all = _db.Chats.Where(s => s.UserId == _userManager.GetUserId(User) || s.To == _userManager.GetUserId(User)).ToList();
            ViewBag.From = all;
            //ViewBag.From = _db.Chats.Where(s => s.).FirstOrDefault();
            return View();
        }
        public List<ChatModel> Get(string id)
        {
            return _db.Chats.Where(s => s.UserId == id).ToList();
        }
        public IActionResult Two(int id)
        {
            var idd = id;
            ViewBag.idd = idd;
            var all = _db.Chats.Where(s => s.UserId == _userManager.GetUserId(User) || s.To == _userManager.GetUserId(User)).ToList();
            ViewBag.all = all;
            //var allPro = _db.Profiles.Where(s => s.UserId == _userManager.GetUserId(User) || s.To == _userManager.GetUserId(User)).ToList();
            /* var all = _db.Chats.ToList();*/
            var allMsgs = _db.Messages.Where(p => p.ChatId == id).Select(p => p.Data).ToList();
            ViewBag.msgs = allMsgs;
            return View();
        }
        public IActionResult Create()
        {
            var all = _db.Profiles.Select(s => s.PhoneNomber).ToList(); ;
            ViewBag.all = all;
            var allName = _db.Profiles.Select(s => s.DisplayName).ToList(); ;
            ViewBag.allNames = allName;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<ChatModel>> CreateChat([Bind("Id", "To", "UserId")] ChatModel chat)
        {
            
            var convertToId = _db.Profiles.First(s => s.PhoneNomber == chat.To).UserId;
            //if (ModelState.IsValid)
            //{
            if (chat.To.Length != 10 && chat.To[0] != 0 && chat.To[1] != 5)
            {
                return BadRequest("Invalid phone number");
            }
            if (!_db.Profiles.Any(o => o.UserId == convertToId))
            {
                /*await _db.Chats.AddAsync(chat);
                await _db.SaveChangesAsync();*/
                return BadRequest("No Phone Number found");
            }
            if (_db.Chats.Any(o => o.To == convertToId || o.UserId == convertToId ))
            {
                var idd = _db.Chats.Where(o => (o.UserId == chat.UserId && o.To == chat.To) || (o.To == chat.UserId && o.UserId == chat.To)).Select(s => s.Id);
                /*await _db.Chats.AddAsync(chat);
                await _db.SaveChangesAsync();*/
                //return BadRequest("already added");
                return Redirect("/Chat/Two/"+ idd);
            }
            /*_db.Chats.Add(chat);
            _db.SaveChanges();*/
            //return RedirectToAction("Index");
            //}
            //return Ok(chat);
            chat.To = convertToId;
            await _db.Chats.AddAsync(chat);
            await _db.SaveChangesAsync();
            return Redirect("/Chat");

        }
    }
}
