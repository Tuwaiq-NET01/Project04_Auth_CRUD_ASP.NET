using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KittyCat.Models
{
    public class CatModel
    {
        public int id { set; get; }
        public string name { set; get; }
        public string age { set; get; }
        public string description { set; get; }
        public string gender { set; get; }
        public string breed { set; get; }
        public string image { set; get; }
        public string health { set; get; }

        //Relationship : One-To-Many: owner => cats
        public OwnerModel Owner { get; set; }

        //FK
        public int OwnerId { get; set; }

        //Relationship : One-To-Many: Adopter => cats
        public AdopterModel Adopter { get; set; }

        //FK
        public int AdopterId { get; set; }

        // navigation properties
        public LocationModel Location { get; set; }

        //FK
        public int LocationId { get; set; }
    }
}
