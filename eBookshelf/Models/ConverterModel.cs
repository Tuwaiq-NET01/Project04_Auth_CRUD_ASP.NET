using System;
using System.ComponentModel.DataAnnotations;

namespace eBookshelf.Models
{

    public class ConverterModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string PageUrl { get; set; }
    }
}
