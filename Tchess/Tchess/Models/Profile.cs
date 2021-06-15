using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Tchess.Models
{
    public class Profile
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        public int NumGames { get; set; }
        public int Win { get; set; }
        public int Rating { get; set; }

        public string Name { get; set; }


        public int Lost
        {
            get { return NumGames - Win; }
        }

        public IdentityUser User { get; set; }
        public string UserId { get; set; }
    }
}