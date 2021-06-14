using HjtProject.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HjtProject.Models
{
    public class CourseModel
    {
       /* List<IdentityUser> emails = RegisterModel.allUsers;*/
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string pic { get; set; }
        public string price { get; set; }
        public InstructorModel Instructor { get; set; }
        public int InstructorId { get; set; }
    }
}
