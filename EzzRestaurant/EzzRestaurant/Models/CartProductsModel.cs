namespace EzzRestaurant.Models
{
    public class CartProductsModel
    {
        public int Id { get; set; }
        
        public CartModal Cart { get; set; }
        public ProductModel Product { get; set; }
        
        
    }
}