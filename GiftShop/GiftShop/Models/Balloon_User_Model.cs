using GiftShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Models
{
    public class Balloon_User_Model
    {
        public int Id { get; set; }

        public int BalloonId { get; set; }
        public BalloonModel Balloon { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
