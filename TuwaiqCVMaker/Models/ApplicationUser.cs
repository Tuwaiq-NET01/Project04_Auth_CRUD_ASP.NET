using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuwaiqCVMaker.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Resumes = new List<Resume>();
            this.Bills = new List<Bill>();
        }

        public bool Active { get; set; }
        public ICollection<Resume> Resumes { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}