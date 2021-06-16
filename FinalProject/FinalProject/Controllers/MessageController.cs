using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MessageController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View("Create");
        }
        public List<MessageModel> Get(int id)
        {
            var all = _db.Messages.Where(s => s.ChatId  == id).ToList();
            return all;
            /*ViewBag.all = all;
            return View("Index");*/
        }
        [HttpPost]
        public async Task<ActionResult<MessageModel>> CreateMsg([Bind("Id", "ChatId", "Timestamp", "Type", "Data", "UserId")] MessageModel msg,int idd)
        {
            //if (ModelState.IsValid)
            //{
            await _db.Messages.AddAsync(msg);
            await _db.SaveChangesAsync();
            /*_db.Chats.Add(chat);
            _db.SaveChanges();*/
            //return RedirectToAction("Index");
            //}
            return Redirect("/Chat/Two/"+msg.ChatId);

        }
    }
}
