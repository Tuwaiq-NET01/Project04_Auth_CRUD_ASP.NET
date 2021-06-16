using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public string PhoneNomber { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public DateTime LastSeen { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
