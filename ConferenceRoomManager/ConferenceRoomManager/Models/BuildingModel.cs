using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceRoomManager.Models
{
    public class BuildingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }

        //public RoomModel Room { get; set; }
        public List<RoomModel> Rooms { get; set; }
        
    }
}
