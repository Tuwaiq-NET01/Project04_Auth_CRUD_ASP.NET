using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Keraa.Models
{
    public class ChatRoomModel
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        
        [ForeignKey("ProductOwnerId")]
        public string ProductOwnerId { get; set; }
        public UserProfileModel ProductOwner { get; set; }


        [ForeignKey("OtherId")]
        public string OtherId { get; set; }
        public UserProfileModel Other { get; set; }
    }
}
