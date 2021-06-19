using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets_Houses.Models
{
    public class Orders_ProductsModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public OrderModel Order { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
    }
}
