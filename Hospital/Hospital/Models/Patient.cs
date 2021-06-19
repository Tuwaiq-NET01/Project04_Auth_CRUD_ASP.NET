using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Patient
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        public string Email { get; set; }

    }
}
