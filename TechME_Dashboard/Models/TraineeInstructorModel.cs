using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechME_Dashboard.Models
{
    public class TraineeInstructorModel
    { 
        [Key]
        public int TraineeInstructor_ID { get; set; }
        public int Trainee_ID { get; set; }
        public TraineeModel Trainee { get; set; }
        public int Instructor_ID { get; set; }
        public InstructorModel Instructor { get; set; }

    }
}
