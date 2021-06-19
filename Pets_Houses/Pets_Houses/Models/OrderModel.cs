using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_Houses.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Date_Time { get; set; }
        public string Address { get; set; }
        public float TotalPrice { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser Users { get; set; } 

        public List<Orders_ProductsModel> Order_Product { get; set; }
    }
}
