using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShopV1.Models
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
