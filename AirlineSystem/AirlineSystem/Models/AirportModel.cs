using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineSystem.Models
{
    public class AirportModel
    {
       [Key]
        public int AirportID { get; set; }
        [ MaxLength(5)]
        public string AirportShort { get; set; }
        public string AirportName { get; set; }
        public string CountryCity { get; set; }
        public string Gate { get; set; }


        //Relationship:One-To-Many Airport -----<-Planes
        //Navigation Propoerties
        public List<PlaneModel> Planes { get; set; }



    }
}
