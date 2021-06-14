using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adoption.Models
{
    public class BreedModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string overview { get; set; }
        public string personality { get; set; }
        public string grooming { get; set; }
    }
}
