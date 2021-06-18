using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenLifeStore.Models
{
    public class OrderProductModel
    {

        //Navigation properties
        public OrderModel Order { get; set; }
        public ProductModel Product { get; set; }

        //FK
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
