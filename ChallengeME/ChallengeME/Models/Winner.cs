using Microsoft.AspNetCore.Identity;
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

        public int wins { get; set; }

        public Comment comment { get; set; }
        public int CommentId { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }


    }
}
