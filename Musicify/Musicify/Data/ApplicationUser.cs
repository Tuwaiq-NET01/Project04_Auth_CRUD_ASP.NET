using Microsoft.AspNetCore.Identity;
using Musicify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicify.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<FavoriteModel> Favorites { get; set; }
    }
}
