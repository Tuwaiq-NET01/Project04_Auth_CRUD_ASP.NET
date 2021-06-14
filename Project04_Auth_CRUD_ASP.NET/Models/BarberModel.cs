using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project04_Auth_CRUD_ASP.NET.Models
{
    public class BarberModel
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public List<PriceModel> Prices { get; set; }
    }
}
