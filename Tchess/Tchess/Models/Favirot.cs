using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tchess.Models
{
    public class Favirot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        
        public Game Game { get; set; }
        public Profile Profile { get; set; }
        public int? GameId { get; set; }
        public int? ProfileId { get; set; }
    }
}