using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task SendMessage(string roomName, string user, string message)
        {
            await Clients.Group(roomName).SendAsync("ReceiveMessage", user, message);
            Console.WriteLine(Context.User.Identity.Name);
            Console.WriteLine(Context.UserIdentifier);
            Console.WriteLine("----send----");
        }

        public async Task JoinRoom(string roomName)
        {
            Console.WriteLine("----join room----");
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage", Context.User.Identity.Name + " joined.");
        }


        public async Task LeaveRoom(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("ReceiveMessage", $"{Context.ConnectionId} has left the group {roomName}.");
            Console.WriteLine("----left room----");
        }

    }
}