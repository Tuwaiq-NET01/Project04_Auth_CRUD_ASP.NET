using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechME_Dashboard.Models
{
    public class TraineeCoursesModel
    {
         [Key]
         public int TraineeCourses_ID { get; set; }
         public int Trainee_ID { get; set; }
        public TraineeModel Trainee { get; set;}
        public int Course_ID { get; set; }
        public CourseModel Course { get; set;}
    }
}
