using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Models
{
    public class FlowerModel
    {
        [Key]
        public int FlowerId { get; set; }
        public string FlowerImage { get; set; }
        public string FlowerName { get; set; }
        public decimal FlowerPrice { get; set; }

    }
}
