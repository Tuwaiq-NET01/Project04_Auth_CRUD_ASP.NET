using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineSystem.Models
{
    public class TripModel
    {
        [Key]
        public int TripNo { get; set; }
        [Required]
        public string TripType { get; set; }
        public int Price { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime TakeOffDateTime { get; set; }
        
        public string CabinClass { get; set; }
        public string RoadType { get; set; }
        public int Weight { get; set; }
        public string Destination { get; set; }


        //Relation Plane----<-Trips
        /*public int PlaneNo { get; set; }
        public PlaneModel Plane { get; set; }*/

        /*  //Relation Trip ---<- Passengers
          public ICollection<PassengerModel> Passangers { get; set; }*/
    }
}
