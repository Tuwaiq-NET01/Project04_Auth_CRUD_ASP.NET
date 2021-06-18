using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenLifeStore.Models
{
    public class BranchProductModel
    {
        //Navigation properties
        public BranchModel Branch { get; set; }
        public ProductModel Product { get; set; }

        //FK
        public int BranchId { get; set; }
        public int ProductId { get; set; }
    }
}
