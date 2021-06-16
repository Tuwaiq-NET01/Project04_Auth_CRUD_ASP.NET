using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GreenLifeStore.Models
{
    public class BranchModel
    {
        [Key]
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        //Navigation properties (one to many) , Branch -> products : one branch has many products
        public List<ProductModel> Products { get; set; }



    }
}
