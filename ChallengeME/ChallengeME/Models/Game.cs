using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeME.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GameName { get; set; }
        public string GameImage{ get; set; }

        public string User_Id { get; set; }

        public List<Challenge> challenges { get; set; }

    }
}
