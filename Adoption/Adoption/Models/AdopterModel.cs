using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adoption.Models
{
    public class AdopterModel
    {
        public int id { set; get; }
        public string name { set; get; }
        public int age { set; get; }
        public string gender { set; get; }
        public string image { set; get; }
        public string occupation { set; get; }
        public string phone { set; get; }
        public string email { set; get; }

        //Relationship : One-To-Many: Adopter => cats
        public List<CatModel> cats { get; set; }


    }
}
