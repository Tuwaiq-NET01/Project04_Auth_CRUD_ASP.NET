using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }

        public ICollection<TeacherCourse> TeacherCourses { get; set; }

    }
}
