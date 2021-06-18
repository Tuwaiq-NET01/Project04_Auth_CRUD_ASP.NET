using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaNodelz.Models;

namespace MaNodelz
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ICollection<RateModel> Rate { get; set; }
        public ICollection<FavoriteModel> Favorites { get; set; }

    }
}
