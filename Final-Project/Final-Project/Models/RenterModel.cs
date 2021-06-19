using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class RenterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }


        // Relationship : one-to-many Renter ------<- Place
        public List<PlaceModel> Places { get; set; }


        // Relationship : one-to-many Renter ------<- Desires
        public List<DesireModel> Desires { get; set; }

    }
}
