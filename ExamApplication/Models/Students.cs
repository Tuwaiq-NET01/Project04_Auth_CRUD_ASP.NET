using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApplication.Models
{
    public class Students
    {
        public long id { get; set; }

        [Required(ErrorMessage = "UserName is required")]

        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
        public long AdminsId { get; set; }
        public Admins Admin { get; set; }
    }
}
