using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechME_Dashboard.Models
{
    public class ContactModel //User
    {
        [Key]
        public int Contact_ID { get; set; } //Hidden
        [Required(ErrorMessage = "Please Enter your Name")]
        [StringLength(20, MinimumLength = 5)]
        public string Sender_Name { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [StringLength(20, MinimumLength = 2)]
        [EmailAddress]
        public string Sender_Email { get; set; }
        [StringLength(20, MinimumLength = 5)]
        [Required(ErrorMessage = "Please Enter Your Message's Subject")]
        public string Masssege_Subject { get; set; }
        [Required(ErrorMessage = "Please Enter Your Message")]
        [StringLength(20, MinimumLength = 5)]
        public string Sender_Massege { get; set; }
    }
}
