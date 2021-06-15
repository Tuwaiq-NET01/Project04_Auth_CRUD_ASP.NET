using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineSystem.Models
{
    public class PlaneModel
    {
        [Key]
        public int PlaneID { get; set; }
        public int Capacity { get; set; }
        public string PlaneName { get; set; }
        public string PlaneType { get; set; }


        //Relationship:One-To-Many Airport -----<-Planes
       
        public AirportModel Airports { get; set; }
        //FK
        public int AirportID { get; set; }


        //Relationship:One-To-Many Plane -----<-Trip
        /// public ICollection<TripModel> Trip { get; set; }



    }
}
