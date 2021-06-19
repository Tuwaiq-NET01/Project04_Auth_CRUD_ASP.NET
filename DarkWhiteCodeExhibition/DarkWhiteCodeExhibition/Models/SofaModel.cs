using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarkWhiteCodeExhibition.Models
{
    public class SofaModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DesignerName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
