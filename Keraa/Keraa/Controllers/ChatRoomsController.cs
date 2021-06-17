using Keraa.Data;
using Keraa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keraa.Controllers
{
    public class ChatRoomsController : Controller
    {
        List<ChatRoomModel> Rooms = new List<ChatRoomModel>() {
        };


        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ChatRoomsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Chat(string OwnerId)
        {
            var user = await _userManager.GetUserAsync(User);
            var room = Rooms.ToList().Find(room => room.OwnerId == OwnerId && room.OtherId == user.Id);
            if (room == null)
            {
                // since the room does not exist, it means that this is the first time for them to chat each other, so create a new one for the room detial in the database.
                Rooms.Add(new ChatRoomModel() { RoomId= "2", OwnerId = OwnerId, OtherId = user.Id});;
                
                room = Rooms.ToList().Find(room => room.OwnerId == OwnerId && room.OtherId == user.Id);
                //return RedirectToAction("Room", "ChatRooms", new { RoomId = room.RoomId });
            }
            return RedirectToAction("Room","ChatRooms",new { RoomId = room.RoomId });
        }

        public async Task<IActionResult> Room(string roomId)
        {   
            var user = await _userManager.GetUserAsync(User);
            var room = Rooms.ToList().Find(room => room.RoomId == roomId && (room.OwnerId == user.Id || room.OtherId == user.Id));
            if (room == null) { return BadRequest(new {Message="You dont have the primisstion to access this room"}); }
            ViewData["RoomId"] = roomId;
            return View();
        }

        public IActionResult Notify(string OwnerId, string RoomId)
        {
            return View();
        }
    }
}
