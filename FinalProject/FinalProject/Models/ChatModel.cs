using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ChatModel
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
