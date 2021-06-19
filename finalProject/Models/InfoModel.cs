using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalProject.Models
{
    public class InfoModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string about { get; set; }

        [ForeignKey ("courses")]
        public int course_id { get; set; }
        public CoursesModel courses { get; set; }
    }
}
