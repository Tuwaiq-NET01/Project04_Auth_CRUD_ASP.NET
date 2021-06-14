namespace EzzRestaurant.Models
{
    public class OrderProductsModel
    {
        public int Id { get; set; }
        
        public OrderModel Order { get; set; }
        public int OrderId { get; set; }
        
        public ProductModel Product { get; set; }
        public int ProductId { get; set; }
    }
}