using GiftShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Models
{
    public class Sweet_User_Model
    {
        public int Id { get; set; }

        public int SweetId { get; set; }
        public SweetModel Sweet { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
