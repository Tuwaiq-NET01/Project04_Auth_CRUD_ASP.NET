using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public List<DropTags> DropTags { get; set; }
    }
}
