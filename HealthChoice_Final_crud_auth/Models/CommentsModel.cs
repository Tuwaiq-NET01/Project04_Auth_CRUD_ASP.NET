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
        
        public int Id { get; set; }
        public string message { get; set; }


        //Relationship : One-To-Many: (Service-to-Comments)
        public ServicesModel Service { get; set; }

        //FK
        public int ServiceId { get; set; }

    

    }
}
