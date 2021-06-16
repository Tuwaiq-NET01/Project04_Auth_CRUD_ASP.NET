using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public ChatModel Chat { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public string Data { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
