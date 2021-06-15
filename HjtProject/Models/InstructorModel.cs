using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HjtProject.Models
{
    public class InstructorModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public string pic { get; set; }
        public OrganizationModel Organization {get; set; } 
        public int? OrganizationId { get; set; }
        public CourseModel Course { get; set; }
        public List<UserProfileModel> UserProfiles { get; set; }



    }
}
