using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eBookshelf.Validation;
using Microsoft.AspNetCore.Http;

namespace eBookshelf.Models
{
    public class EbookViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[Required]
        //public string Author { get; set; }
        //public string CoverImg { get; set; }

        [AllowedExtensions(new string[] { ".epub"})]
        public IFormFile Content { get; set; }
       // public DateTime CreationDate { get; set; }

    }
}
