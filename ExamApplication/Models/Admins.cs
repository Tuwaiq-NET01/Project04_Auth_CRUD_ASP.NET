using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamApplication.Models
{
    public class Admins
    {
        public long id { get; set; }

        [Required(ErrorMessage = "UserName is required")]

        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public List<Students> student { get; set; }
        public Exam exam { get; set; }




    }
}

