using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KittyCat.Models
{
    public class LocationModel
    {
        public int id { set; get; }
        public string name { set; get; }
        public string phone { set; get; }
        public string address { set; get; }

        // navigation properties
        public CatModel cat { get; set; }
    }
}
