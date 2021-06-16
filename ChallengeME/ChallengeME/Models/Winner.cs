using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeME.Models
{
    public class Winner
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }


        public Challenge Challenge { get; set; }
        public int? ChallengeId { get; set; }


        public Comment Comment { get; set; }
        public int? CommentId { get; set; }



    }
}
