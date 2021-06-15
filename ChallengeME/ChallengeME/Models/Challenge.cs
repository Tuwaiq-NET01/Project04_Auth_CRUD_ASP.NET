using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeME.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter the name of the challenge!")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Difficulty{ get; set; }


        public Game Game { get; set; }
        public int GameId{ get; set; }

        public IdentityUser User { get; set; }
        public string UserId { get; set; }


    }
}
