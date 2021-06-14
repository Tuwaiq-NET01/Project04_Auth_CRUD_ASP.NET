using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace circus.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        //nav
        public ShowModel Show { get; set; }
        public int ShowId { get; set; }
        //nav
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
    }
}
