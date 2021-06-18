using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaNodelz.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public FoodModel Food { get; set; }
        public int FoodId { get; set; }
    }
}
