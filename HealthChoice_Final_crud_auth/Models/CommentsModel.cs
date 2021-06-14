using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Final_crud_auth.Models
{
    public class CommentsModel
    {
        [Key]
        
        public int comId { get; set; }
        public string message { get; set; }

      

    }
}
