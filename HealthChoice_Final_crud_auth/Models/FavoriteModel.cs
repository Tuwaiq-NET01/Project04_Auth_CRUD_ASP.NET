using HealthChoice_Final_crud_auth.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Final_crud_auth.Models
{
    public class FavoriteModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public EventsModel Events { get; set; }
    }
}
