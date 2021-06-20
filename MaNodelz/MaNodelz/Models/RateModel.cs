using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MaNodelz.Models
{
    public class RateModel
    {
        public int Id { get; set; }
        /// <summary>
        /// / Total Rate is the summation of rate / NOF
        ///  /*[Column(TypeName = "decimal(18,4)")]*/
        /// </summary>


        [Required]
        [DisplayName("Rate")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 5.00, ErrorMessage = "Rate should be between 0-5:00")]
        public decimal RateByuser { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999.00)]
        public decimal TotalRate { get; set; }
        public int NumberOfRatesOnFood { get; set; }

        public FoodModel Food { get; set; }
        public int FoodId { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
    }
}
