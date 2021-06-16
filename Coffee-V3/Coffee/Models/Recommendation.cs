using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Models
{
    public class Recommendation
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string AvailabilityLoc { get; set; }

        //FK
        public string UserId { get; set; }
        [ForeignKey("UserId")]

        public IdentityUser Users { get; set; }


    }
}
