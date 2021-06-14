using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HjtProject.Models
{
    public class OrganizationModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public string pic { get; set; }
        public List<InstructorModel> Instructors { get; set; }
     

    }
}
