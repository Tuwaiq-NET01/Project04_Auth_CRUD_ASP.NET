using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceRoomManager.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public string Image { get; set; }

        public BuildingModel Building { get; set; }
        public int BuildingId { get; set; }


        public List<BookingModel> Bookings { get; set; }


        public int FacilityId { get; set; }
        public FacilityModel Facility { get; set; }
        
        



    }
}
