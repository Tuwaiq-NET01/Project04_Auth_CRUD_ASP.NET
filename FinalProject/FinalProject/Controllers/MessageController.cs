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
        public ActionResult<MessageModel> CreateMsg([FromBody] MessageModel msg)
        {
            //if (ModelState.IsValid)
            //{
            Console.WriteLine("00000000000000000000000000000000000000000000000000");
            Console.WriteLine(msg.ChatId);
            if(msg.Data == "" || msg.Data.Length <=0) return Ok(msg);
            _db.Messages.Add(msg);
            _db.SaveChanges();
            Console.WriteLine("77777777777777777777777777777777777777777777");
            /*_db.Chats.Add(chat);
            _db.SaveChanges();*/
            //return RedirectToAction("Index");
            //}
            return Ok(msg);
            //return Redirect("/Chat/Two/"+msg.ChatId);

        }
        // POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var msg =_db.Messages.Find(id);
            _db.Messages.Remove(msg);
            await _db.SaveChangesAsync();
            return Redirect("/Chat/Two/" + msg.ChatId);
        }
    }
}
