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
        public int memId { get; set; }
        public string memName { get; set; }
        public string memBenefits { get; set; }

    
    }
}
