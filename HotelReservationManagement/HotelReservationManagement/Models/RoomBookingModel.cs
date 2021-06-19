using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManagement.Models
{
    public class RoomBookingModel
    {
        [Key]
        public int RoomBookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        [Required]
        public int NumberOfGuests { get; set; }
        public bool IsLateCheckout { get; set; }

        public int RoomId { get; set; }
        public virtual RoomModel Room { get; set; }
        public string UserId { get; set; }
        public virtual AdvanceUser User { get; set; }
    }
}
