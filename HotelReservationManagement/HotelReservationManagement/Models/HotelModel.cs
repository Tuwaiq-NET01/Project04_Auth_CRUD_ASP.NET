using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManagement.Models
{
    public class HotelModel
    {
        [Key]
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelImage { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
