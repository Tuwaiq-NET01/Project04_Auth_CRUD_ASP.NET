using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalProject.Models
{
    public class StudentModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public List<Files_UploadedModel> Files { get; set; }
    }
}
