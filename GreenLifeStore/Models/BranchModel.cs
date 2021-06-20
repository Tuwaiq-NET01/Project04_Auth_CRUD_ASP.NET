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
        public string City { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }




        public List<BranchProductModel> BranchProduct { get; set; }




    }
}
