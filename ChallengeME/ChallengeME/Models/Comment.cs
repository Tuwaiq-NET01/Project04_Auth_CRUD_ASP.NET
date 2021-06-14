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
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }


        public Challenge challenge{ get; set; }
        public int ChallengeId { get; set; }

        public string UserId { get; set; }


    }
}
