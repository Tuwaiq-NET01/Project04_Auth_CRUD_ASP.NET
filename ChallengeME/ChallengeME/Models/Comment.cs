using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeME.Models
{
    public class Comment
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please type your comment!")]
        public string Title { get; set; }
        public string Body { get; set; }

        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Time { get; set; }

        public bool isWinner { get; set; }

        public Challenge challenge{ get; set; }
        public int ChallengeId { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

    }
}
