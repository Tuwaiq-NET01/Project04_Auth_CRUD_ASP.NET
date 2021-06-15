using HealthChoice_Final_crud_auth.Data;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Final_crud_auth.Models
{
    public class MembershipsModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Benefits { get; set; }

        //Relationship One-to-Many
        public List<ServicesModel> Services { get; set; }



    }
}
