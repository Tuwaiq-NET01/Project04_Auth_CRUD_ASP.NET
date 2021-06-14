using System;
using System.Collections.Generic;

namespace EzzRestaurant.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        
        public List<ProductModel> Products { get; set; }
    }
}