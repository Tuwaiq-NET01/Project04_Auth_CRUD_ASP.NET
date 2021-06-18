using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMVC.Models
{
    public class ContactModel
    {
        [Key]
        public int  ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string  PhoneNo { get; set; }
        public string Massage { get; set; }

        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }
    }
}
