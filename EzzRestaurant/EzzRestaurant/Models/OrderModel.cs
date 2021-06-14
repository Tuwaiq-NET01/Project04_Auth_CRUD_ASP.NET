namespace EzzRestaurant.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        
        public UserModel User { get; set; }
        public int UserId { get; set; }
        
    }
}