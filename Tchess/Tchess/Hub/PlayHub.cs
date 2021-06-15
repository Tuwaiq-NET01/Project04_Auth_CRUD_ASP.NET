using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Tchess.Hub
{
    public class PlayHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.Client(user).SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendNetwork(string user, string message)
        {
            await Clients.Others.SendAsync("ReceiveNetwork", Context.ConnectionId,message);
        }

        public async Task SendToId(string user, string message)
        {
            await Clients.Client(user).SendAsync("ReceiveId", Context.ConnectionId,message);
        }
    }
}