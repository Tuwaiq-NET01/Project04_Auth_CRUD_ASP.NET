using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuwaiqCVMaker.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Resume> Resumes { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}