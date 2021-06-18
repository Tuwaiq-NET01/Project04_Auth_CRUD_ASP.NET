using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaNodelz.Models
{
    public class FavoriteModel
    {
        public int Id { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "")]
        public bool Fav { get; set; }

        public ApplicationUser User { get; set; }
        public int UserId { get; set; }

        public FoodModel Food { get; set; }
        public int FoodId { get; set; }
    }
}
