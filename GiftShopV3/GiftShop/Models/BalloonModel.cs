using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Models
{
    public class BalloonModel
    {
        [Key]
        public int BalloonId { get; set; }
        public string BalloonImage { get; set; }
        public string BalloonName { get; set; }
        public decimal BalloonPrice { get; set; }

        public List<Balloon_User_Model> Balloon_User { get; set; }

    }
}
