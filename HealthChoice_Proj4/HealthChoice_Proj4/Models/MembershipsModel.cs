using HealthChoice_Proj4.Data;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Proj4.Models
{
    public class MembershipsModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Benefits { get; set; }

       
        public List<ApplicationUser> Users { get; set; }




    }
}
