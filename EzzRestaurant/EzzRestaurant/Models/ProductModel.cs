using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        public Collection<CartModal> Products { get; set; } // The name should be [Carts] but the copy and paste is the problem
        
        public ICollection<OrderModel> Orders { get; set; }

    }
}