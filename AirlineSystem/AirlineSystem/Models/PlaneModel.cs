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
       /* //Relationship:One-To-Many Airports -----<-Planes
        //FK
        public int Airport_ID { get; set; }
        public AirportModel Airports { get; set; }

        //Relationship:One-To-Many Plane -----<-Trip
        public List<TripModel> Trip { get; set; }*/



    }
}
