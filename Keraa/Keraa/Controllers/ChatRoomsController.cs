using Keraa.Data;
using Keraa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keraa.Controllers
{
    public class ChatRoomsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ChatRoomsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var UserChats = _db.ChatRooms.Include(c => c.ProductOwner).Include(c => c.Other).Where(u => u.ProductOwnerId == user.Id || u.OtherId == user.Id).ToList();
            //var UserChats = _db.ChatRooms.Where(u => u.ProductOwnerId == user.Id || u.OtherId == user.Id).ToList();
            ViewData["UserChats"] = UserChats;
            return View( new { ist= true });
        }

        public async Task<IActionResult> Chat(string OwnerId)
        {
            var user = await _userManager.GetUserAsync(User);
            var room = _db.ChatRooms.ToList().Find(room => room.ProductOwnerId == OwnerId && room.OtherId == user.Id);
            if (room == null)
            {
                string room_id = Guid.NewGuid().ToString("N"); // Represents: a globally unique identifier (GUID).
                
                // since the room does not exist, it means that this is the first time for them to chat each other, so create a new one for the room detial in the database.
                _db.ChatRooms.Add(new ChatRoomModel() { RoomId= room_id, ProductOwnerId = OwnerId, OtherId = user.Id});;
                await _db.SaveChangesAsync();

                room = _db.ChatRooms.ToList().Find(room => room.ProductOwnerId == OwnerId && room.OtherId == user.Id);
                //return RedirectToAction("Room", "ChatRooms", new { RoomId = room.RoomId });
            }
            return RedirectToAction("Room","ChatRooms",new { RoomId = room.RoomId });
        }

        public async Task<IActionResult> Room(string roomId)
        {   
            var user = await _userManager.GetUserAsync(User);
            // var room = _db.ChatRooms.ToList().Find(room => room.RoomId == roomId && (room.ProductOwnerId == user.Id || room.OtherId == user.Id));
            var room = _db.ChatRooms.Include(c => c.ProductOwner).Include(c => c.Other).ToList().Find(room => room.RoomId == roomId && (room.ProductOwnerId == user.Id || room.OtherId == user.Id));

            if (room == null) { return BadRequest(new {Message="You dont have the primisstion to access this room"}); }
             var userProfile = _db.UserProfiles.ToList().Find(profile => profile.Id == user.Id);
            ViewBag.Profile = userProfile;
            ViewBag.roomInfo = room;
            return View();
            // var roomInfo = new { RoomId = room.RoomId, UserName = userProfile.Name, UserImage = userProfile.Image};
            //return Ok(roomInfo);
        }

        public IActionResult Notify(string OwnerId, string RoomId)
        {
            return View();
        }
    }
}

/*
var roomInfo =
    from category in _db.ChatRooms
    join prod in _db.UserProfiles on category.OtherId equals prod.Id
    select new { ProductName = prod.Name, Category = category.RoomId };*/