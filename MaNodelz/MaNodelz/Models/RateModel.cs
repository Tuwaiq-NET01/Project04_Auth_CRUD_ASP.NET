using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaNodelz.Models
{
    public class RateModel
    {
        public int Id { get; set; }
        [DisplayName("Rate")]
        [Range(0.00,5.00,ErrorMessage = "Rate should be between 0:00-5:00")]
        public decimal TotalRate { get; set; }
        public int NumberOfRatesOnFood { get; set; }

        public FoodModel Food { get; set; }
        public int FoodId { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
    }
}
