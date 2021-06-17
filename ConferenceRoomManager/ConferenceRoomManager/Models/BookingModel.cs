using ConferenceRoomManager.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceRoomManager.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }


        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public RoomModel Room { get; set; }
        public int RoomId { get; set; }


    }
}
