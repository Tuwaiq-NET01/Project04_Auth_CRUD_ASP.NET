using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace finalProject.Models
{
    public class InstructorModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}
