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
        public string path { get; set; }

        [ForeignKey("courses")]
        public int course_id { get; set; }
        public CoursesModel courses { get; set; }

    }
}
