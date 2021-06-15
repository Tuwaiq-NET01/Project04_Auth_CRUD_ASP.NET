using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HjtProject.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public CourseModel Course { get; set; }
        public int? CourseId { get; set; }

        public InstructorModel Instructor { get; set; }
        public int? InstructorId { get; set; }


    }
}
