using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<StudentTeacher> StudentTeachers { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; }
    }
}
