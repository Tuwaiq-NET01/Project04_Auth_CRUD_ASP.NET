using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project04_Auth_CRUD_ASP.NET.Models
{
    public class ReservationModel
    {
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        public PriceModel Price { get; set; }
        public Guid PriceId { get; set; }
        public IdentityUser User { get; set; }
        public Guid UserId { get; set; }
    }
}
