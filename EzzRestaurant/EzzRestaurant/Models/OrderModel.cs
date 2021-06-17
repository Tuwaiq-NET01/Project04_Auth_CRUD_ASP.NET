using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EzzRestaurant.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        
        public ICollection<ProductModel> Products { get; set; }
        
    }
}