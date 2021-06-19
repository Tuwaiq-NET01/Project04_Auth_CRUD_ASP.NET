using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class DesireModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        // Relationship : one-to-many Desires ->------ Renter
        public int RenterId { get; set; }
        public RenterModel Renter { get; set; }
    }
}
