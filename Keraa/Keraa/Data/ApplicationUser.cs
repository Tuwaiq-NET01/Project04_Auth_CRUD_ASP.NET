using Keraa.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keraa.Data
{
    public class ApplicationUser: IdentityUser
    {
        public UserProfileModel UserProfile { get; set; }
    }
}
