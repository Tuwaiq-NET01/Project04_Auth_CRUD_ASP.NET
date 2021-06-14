using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManagement.Models
{
    public class ProfileModel
    {
        [Key]
        public int ProfileId { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        //public string UserPassword { get; set; }
        public int UserPhoneNumber { get; set; }
        public string City { get; set; }
        //public string State { get; set; }
    }
}
