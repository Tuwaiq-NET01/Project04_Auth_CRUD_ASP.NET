using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechME_Dashboard.Models
{
    public class CourseModel
    {
        [Key]
        public int Course_ID { get; set; }
        [Required(ErrorMessage = "Please Enter  Coures Name")]
        [StringLength(20, MinimumLength = 5)]
        public string Course_Name { get; set; }
        [Required(ErrorMessage = "Please Enter Coures Category")]
        [StringLength(20, MinimumLength = 5)]
        public string Course_Category { get; set; } //Drop Down List
        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(20, MinimumLength = 5)]
        public string Course_Description { get; set; }
        public string Course_Image { get; set; }
    }
}
