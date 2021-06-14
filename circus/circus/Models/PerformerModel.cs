using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace circus.Models
{
    public class PerformerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Profession { get; set; }
        //
        public List<ShowModel> Shows { get; set; }

    }
}
