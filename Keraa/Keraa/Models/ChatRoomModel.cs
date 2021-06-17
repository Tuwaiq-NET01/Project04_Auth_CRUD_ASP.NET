using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keraa.Models
{
    public class ChatRoomModel
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public string OwnerId { get; set; }
        public string OtherId { get; set; }
    }
}
