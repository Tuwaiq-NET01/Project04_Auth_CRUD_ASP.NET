using finalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalProject.Models
{
    public class CoursesModel
    {
        public int id { get; set; }
        public string subject { get; set; }

        public List<Files_UploadedModel> Files { get; set; }
        public List<CommentModel> Comments { get; set; }


    }
}
