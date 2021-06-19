using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.Models
{
    public class PlaceModel 
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Img { get; set; }


        // Relationship : one-to-many : Place  ->------ Lessor

        public int LessorId { get; set; }
        public LessorModel Lessor { get; set; }

        // Relationship : one-to-many Place ->------ Renter
        public int RenterId { get; set; }
        public RenterModel Renter { get; set; }

    }
}
