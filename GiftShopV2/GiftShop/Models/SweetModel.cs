using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Models
{
    public class SweetModel
    {
        [Key]
        public int SweetId { get; set; }
        public string SweetImage { get; set; }
        public string SweetName { get; set; }
        public decimal SweetPrice { get; set; }
    }
}
