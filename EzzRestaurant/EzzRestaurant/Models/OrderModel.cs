using Microsoft.AspNetCore.Identity;

namespace EzzRestaurant.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
        
    }
}