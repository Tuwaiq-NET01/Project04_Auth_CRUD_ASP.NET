using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Appointment
    {
        [Required]
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Speciality { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime Time { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
