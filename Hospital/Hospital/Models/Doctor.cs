using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Doctor
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Speciality { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
