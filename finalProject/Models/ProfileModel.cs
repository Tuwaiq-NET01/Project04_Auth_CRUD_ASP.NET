using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalProject.Models
{
    public class ProfileModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string img { get; set; }


        public List<CoursesModel> Courses { get; set; }

    }
}
