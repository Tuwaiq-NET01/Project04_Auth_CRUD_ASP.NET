using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreenLifeStore.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductDetails { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }

        //Navigation properties (one to many) , Product -> Branch : one product is only in one branch
        public BranchModel Branch { get; set; }
        //FK
        public int BranchId { get; set; }

        //Navigation properties (one to many) , Order -> Product : one product is only in one order
        public OrderModel Order { get; set; }
        //FK
        public int OrderId { get; set; }

    }
}
