using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace EzzRestaurant.Models
{
    public class CartModal
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        
        public Collection<ProductModel> Products { get; set; }

    }
}