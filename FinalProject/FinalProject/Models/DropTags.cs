using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class DropTags
    {
        public int DropId { get; set; }
        public Drop Drop { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
