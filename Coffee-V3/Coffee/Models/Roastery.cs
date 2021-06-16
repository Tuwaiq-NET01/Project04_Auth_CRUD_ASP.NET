using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.Models
{
    public class Roastery
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public double Rate { get; set; }

        //Relationship : One-To-Many
        public List<Bean> Beans { get; set; }
    }
}
