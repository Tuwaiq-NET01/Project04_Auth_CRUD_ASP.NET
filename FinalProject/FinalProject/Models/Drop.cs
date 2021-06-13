using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Drop
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
    }
}
