using HealthChoice_Proj4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Proj4.Models
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
