using System;
using System.ComponentModel.DataAnnotations;

namespace EzzRestaurant.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public double Price { get; set; }
        
        [Required]
        public string img { get; set; }
        
        
        public CategoryModel Category { get; set; } 
        
        [Required]
        public int CategoryId { get; set; }
    }
}