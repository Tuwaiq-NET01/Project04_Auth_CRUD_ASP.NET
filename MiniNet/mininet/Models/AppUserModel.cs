using System;
using Microsoft.AspNetCore.Identity;
namespace mininet.Models
{
    public class AppUser : IdentityUser
    {
        public ProfileModel profile;
    }
}