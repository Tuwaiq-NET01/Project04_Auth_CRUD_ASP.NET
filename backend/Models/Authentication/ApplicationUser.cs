using Microsoft.AspNetCore.Identity;
using System;

namespace backend.Models.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string AccountType { get; set; }
        public uint CurrentQuota { get; set; }
        public uint TotalQuota { get; set; }
    }
}
