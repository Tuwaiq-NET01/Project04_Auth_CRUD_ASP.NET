using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tchess.Models
{
    public class Game
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public string Moves { get; set; }
        public string Winner { get; set; }
        public string NumMoves { get; set; }
        
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
        

    }
}