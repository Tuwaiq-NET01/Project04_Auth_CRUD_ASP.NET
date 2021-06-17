using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceRoomManager.Models
{
    public class FacilityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

         public List<RoomModel> Rooms { get; set; }
    }
}
