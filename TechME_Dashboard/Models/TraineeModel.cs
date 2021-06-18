using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechME_Dashboard.Models
{
    public class TraineeModel
    {

        [Key]
        public int Trainee_ID { get; set; }
        [Required(ErrorMessage = "Please Enter Instructor's Name")]
        [StringLength(20, MinimumLength = 2)]
        public string Trainee_Name { get; set; }
        [Required(ErrorMessage = "Please Enter Instructor's BIO")]
        [StringLength(20, MinimumLength = 2)]
        public string Trainee_BIO { get; set; }
        public string Trainee_Image { get; set; }
    }
}
