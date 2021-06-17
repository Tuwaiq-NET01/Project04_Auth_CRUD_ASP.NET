using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManagement.Models
{
    public class RoomBookingModel
    {
        [Key]
        [Required]
        public int RoomBookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public bool IsLateCheckout { get; set; }

    }
}
