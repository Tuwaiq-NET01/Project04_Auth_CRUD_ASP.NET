using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineSystem.Models
{
    public class PassengerModel
    {
        [Key]
        public int PassengerID { get; set; }
        [Required]
        public int PassportNo { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Gender  { get; set; }
        [Required]
        public string Nationality { get; set; }

      /*  //Relation Trip ---<- Passengers
       public int TripNo { get; set; }
       public virtual TripModel Trip { get; set; }*/

    }
}
