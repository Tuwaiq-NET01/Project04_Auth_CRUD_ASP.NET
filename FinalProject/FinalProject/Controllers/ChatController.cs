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
        /*public ChatController(ApplicationDbContext context)
        {
            _db = context;
        }*/
        public IActionResult Index()
        {
            var all = _db.Chats.Where(s => s.UserId == _userManager.GetUserId(User) || s.To == _userManager.GetUserId(User)).ToList();
            ViewBag.all = all;
            var allPro = _db.Profiles.ToList();
            ViewBag.pro = allPro;
            return View();
        }
        public List<ChatModel> Get(int id)
        {
            return _db.Chats.Where(s => s.Id == id).ToList();
        }
        public int GetChat(int id)
        {
            var res = _db.Chats.Where(s => s.Id == id).Select(s => s.Id).FirstOrDefault();
            if(res == id)
            return id;
            return 0;
        }
        public IActionResult Two(int id)
        {
            var idd = id;
            ViewBag.idd = idd;
            var all = _db.Chats.Where(s => s.UserId == _userManager.GetUserId(User) || s.To == _userManager.GetUserId(User)).ToList();
            ViewBag.all = all;
            var allPro = _db.Profiles.ToList();
            ViewBag.pro = allPro;
            var img1 = _db.Chats.Where(s => s.UserId == _userManager.GetUserId(User)).Select(s => s.To).FirstOrDefault();
            var img2 = _db.Chats.Where(s => s.To == _userManager.GetUserId(User)).Select(s => s.UserId).FirstOrDefault();
            var temp = (_userManager.GetUserId(User) == img1 ? img2 : img1);
            var toImg = _db.Profiles.Where(s => s.UserId == temp).Select(s => s.Image).FirstOrDefault();
            ViewBag.img = toImg;
            var allMsgs = _db.Messages.Where(p => p.ChatId == id).ToList();
            ViewBag.msgs = allMsgs;
            return View();
        }
        public IActionResult Create()
        {
            var all = _db.Profiles.Select(s => s.PhoneNomber).ToList(); ;
            ViewBag.all = all;
            var allName = _db.Profiles.Select(s => s.DisplayName).ToList(); ;
            ViewBag.allNames = allName;
            var img = _db.Profiles.Where(s => s.UserId == _userManager.GetUserId(User)).Select(s => s.Image).FirstOrDefault();
            ViewBag.img = img;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<ChatModel>> CreateChat([Bind("Id", "To", "UserId")] ChatModel chat)
        {
            
            var convertToId = _db.Profiles.First(s => s.PhoneNomber == chat.To).UserId;
            if (chat.To.Length != 10 && chat.To[0] != 0 && chat.To[1] != 5)
            {
                return BadRequest("Invalid phone number");
            }
            if (!_db.Profiles.Any(o => o.UserId == convertToId))
            {
                return BadRequest("No Phone Number found");
            }
            if (_db.Chats.Any(o => (o.UserId == _userManager.GetUserId(User) && o.To == convertToId) || (o.To == _userManager.GetUserId(User) && o.UserId == convertToId)))
            {
                var idd = _db.Chats.Where(o => (o.UserId == _userManager.GetUserId(User) && o.To == convertToId) || (o.To == _userManager.GetUserId(User) && o.UserId == convertToId)).Select(s => s.Id);
                
                return Redirect("/Chat/Two/"+ idd.FirstOrDefault());
            }
            chat.To = convertToId;
            await _db.Chats.AddAsync(chat);
            await _db.SaveChangesAsync();
            var idd1 = _db.Chats.Where(o => (o.UserId == _userManager.GetUserId(User) && o.To == convertToId) || (o.To == _userManager.GetUserId(User) && o.UserId == convertToId)).Select(s => s.Id);

            return Redirect("/Chat/Two/" + idd1.FirstOrDefault());

        }
    }
}
