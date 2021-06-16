using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalProject.Models
{
    public class CommentModel
    {
        public int id { get; set; }
        public string CommentContent { get; set; }

        [ForeignKey("CoursesModel")]
        public int course_id { get; set; }
    }
}
