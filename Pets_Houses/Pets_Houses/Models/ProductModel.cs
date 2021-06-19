using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_Houses.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }

        public List<Orders_ProductsModel> Order_Product { get; set; }
    }
}
