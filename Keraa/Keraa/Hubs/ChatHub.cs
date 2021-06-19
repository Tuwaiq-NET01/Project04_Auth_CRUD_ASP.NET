using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keraa.Data;
using Microsoft.AspNetCore.SignalR;

namespace Keraa.Hubs
{
    public class ChatHub : Hub
    {
        /*public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            Console.WriteLine(Context.User.Identity.Name);
            Console.WriteLine(Context.UserIdentifier);
        }*/
        private readonly ApplicationDbContext _db;
        public ChatHub(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task SendMessage(string roomName, string user, string message)
        {
            var userImage = _db.UserProfiles.ToList().Find(user => user.Id == Context.UserIdentifier).Image;
            await Clients.Group(roomName).SendAsync("ReceiveMessage", user, message, Context.UserIdentifier, userImage);
            Console.WriteLine(Context.User.Identity.Name);
            Console.WriteLine(Context.UserIdentifier);
            Console.WriteLine("----send----");
        }

        public async Task JoinRoom(string roomName)
        {
            Console.WriteLine("----join room----");
            var userName = _db.UserProfiles.ToList().Find(user => user.Id == Context.UserIdentifier).Name;
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveNotify", userName + " has joined the room.");
        }


        public async Task LeaveRoom(string roomName)
        {
            var userName = _db.UserProfiles.ToList().Find(user => user.Id == Context.UserIdentifier).Name;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveNotify", $"{userName} just left the room.");
            Console.WriteLine("----left room----");
        }
    }
}