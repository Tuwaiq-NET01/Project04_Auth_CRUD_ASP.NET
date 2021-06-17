using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationManagement.Models
{
    public class RoomModel
    {
        [Key]
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomImage { get; set; }
        [Column (TypeName="decimal(18,2)")]
        public decimal RoomPrice { get; set; }
        public string RoomType { get; set; }
        public string RoomDescribtion { get; set; }
        public string RoomStatus { get; set; }
        public string Floor { get; set; }
        public string PersonCapacity { get; set; }

        //one to many with hotel
        public int HotelId { get; set; }
        public virtual HotelModel Hotel { get; set; }

    }
}
