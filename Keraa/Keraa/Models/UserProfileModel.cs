using Keraa.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Keraa.Models
{
    public class UserProfileModel
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public bool IsOnline { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [InverseProperty("Owner")]
        public List<ProductModel> OwnerProducts { get; set; }

        [InverseProperty("Tenant")]
        public List<ProductModel> TenantProducts { get; set; }


        [InverseProperty("ProductOwner")]
        public List<ChatRoomModel> ProductOwnerChatRooms { get; set; }

        [InverseProperty("Other")]
        public List<ChatRoomModel> OtherChatRooms { get; set; }
    }
}
