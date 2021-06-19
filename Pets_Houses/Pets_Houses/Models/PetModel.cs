using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_Houses.Models
{
    public class PetModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string  Details { get; set; }
        public int ContactNo { get; set; }

        public string  UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser Users { get; set; }
    }
}
