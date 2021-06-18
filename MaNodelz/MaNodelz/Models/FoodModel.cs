using MaNodelz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MaNodelz.Models
{
    public class FoodModel
    {
       
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }

        public string FoodImage { get; set; }

        [Range(typeof(TimeSpan), "00:00", "23:59", ErrorMessage = "Time must be between 00:00 to 23:59")]
        public TimeSpan FoodTobePrepared { get; set; }
        public string FoodType { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
    }
}
