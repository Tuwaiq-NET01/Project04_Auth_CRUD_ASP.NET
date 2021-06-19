using System.ComponentModel.DataAnnotations;

namespace Induction.Models
{
    public class FlashCardModel
    {
        public int id { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set;  }
    }
}