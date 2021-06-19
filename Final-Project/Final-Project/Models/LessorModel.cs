using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class LessorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }


        // Relationship : one-to-many Lessor ------<- Place
        public List<PlaceModel> Places { get; set; }

    }
}
