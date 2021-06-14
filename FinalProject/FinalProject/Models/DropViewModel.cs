using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class DropViewModel
    {
        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }

        public ApplicationUser User { get; set; }
    }
}
