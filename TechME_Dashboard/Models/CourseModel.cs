using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TechME_Dashboard.Models;

namespace TechME_Dashboard.Models
{
    public class CourseModel
    {
        [Key]
        public int Course_ID { get; set; }
        [Required(ErrorMessage = "Please Enter  Coures Name")]
        [StringLength(20, MinimumLength = 2)]
        public string Course_Name { get; set; }
        [Required(ErrorMessage = "Please Enter Coures Category")]
        [StringLength(20, MinimumLength = 2)]
        public string Course_Category { get; set; } //Drop Down List
        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(20, MinimumLength = 2)]
        public string Course_Description { get; set; }
        [Required(ErrorMessage ="Please Enter The Course's Start Date")]
        public DateTime Course_Start_Date { get; set; }
        [Required(ErrorMessage = "Please Enter The Course's End  Date")]
        public DateTime Course_End_Date { get; set; }
        public string Course_Image { get; set; }
        [ForeignKey("Instructor")]
        public int Instructor_ID { get; set; }
        public InstructorModel Instructor { get; set; }
        public ICollection<TraineeCoursesModel> TraineeCourses { get; set; }

     
    }
}
