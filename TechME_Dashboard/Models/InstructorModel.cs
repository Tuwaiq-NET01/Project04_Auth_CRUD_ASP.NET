using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechME_Dashboard.Models
{
    public class InstructorModel
    {
        [Key]
        public int Instructor_ID { get; set; }
        [Required(ErrorMessage = "Please Enter Instructor's Name")]
        [StringLength(20, MinimumLength = 5)]
        public string Instructor_Name { get; set; }
        [Required(ErrorMessage = "Please Enter Instructor's BIO")]
        [StringLength(20, MinimumLength = 5)]
        public string Instructor_BIO { get; set; }

        public string Instructor_Image { get; set; }
    }
}
