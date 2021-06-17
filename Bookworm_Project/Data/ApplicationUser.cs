using Bookworm_Project.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookworm_Project.Data
{
    public class ApplicationUser : IdentityUser
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected UserManager<ApplicationUser> UserManager { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set;  }

        //Relationship : One-To-Many: Users => Reviews
        public List<ReviewModel> Reviews { get; set; }
    }
}
