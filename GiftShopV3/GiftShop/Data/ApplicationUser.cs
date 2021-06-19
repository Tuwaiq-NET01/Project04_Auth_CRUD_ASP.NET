using GiftShop.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Data
{
    public class ApplicationUser : IdentityUser
    {
        public List<Flower_User_Model> Flower_User { get; set; }
        public List<Sweet_User_Model> Sweet_User { get; set; }
        public List<Balloon_User_Model> Balloon_User { get; set; }

    }
}
