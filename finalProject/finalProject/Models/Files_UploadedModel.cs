using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalProject.Models
{
    public class Files_UploadedModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }

        [ForeignKey("StudentModel")]
        public int student_id { get; set; }
        [ForeignKey("CoursesModel")]
        public int course_id { get; set; }




    }
}
