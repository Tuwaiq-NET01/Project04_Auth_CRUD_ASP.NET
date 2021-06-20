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
            return _db.Messages.Where(s => s.ChatId == id).ToList(); ;
        }
        [HttpPost]
        public ActionResult<MessageModel> CreateMsg([FromBody] MessageModel msg)
        {
            if(msg.Data == "" || msg.Data.Length <=0) return Ok(msg);
            _db.Messages.Add(msg);
            _db.SaveChanges();
            
            return Ok(msg);

        }
        public async Task<IActionResult> Delete(int id)
        {
            var msg =_db.Messages.Find(id);
            _db.Messages.Remove(msg);
            await _db.SaveChangesAsync();
            return Redirect("/Chat/Two/" + msg.ChatId);
        }
    }
}
