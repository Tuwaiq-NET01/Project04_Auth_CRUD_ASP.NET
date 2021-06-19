using System.ComponentModel.DataAnnotations;

namespace Induction.Models
{
    public class QouteModel
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        
    }
}