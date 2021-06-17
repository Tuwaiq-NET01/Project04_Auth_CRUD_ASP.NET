using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public string Location { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
