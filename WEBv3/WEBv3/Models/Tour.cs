using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WEBv3.Models;

namespace WEBv3.Models
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; }

        [Column(TypeName = "varchar(500)")]

        public string Place { get; set; }
        [Column(TypeName = "varchar(600)")]

        public string Description { get; set; }
        [Column(TypeName = "varchar(50)")]

        public string AdultPrice { get; set; }
        [Column(TypeName = "varchar(50)")]

        public string ChildPrice { get; set; }
        [Column(TypeName = "varchar(100)")]

        public string PickupLocation { get; set; }
        public DateTime ReturnsAt { get; set; }
        public DateTime DepartsAt { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public string ImageSrc { get; set; }



        public ICollection<Booking> Bookings { get; set; }
        public Included Included { get; set; }

         public string UserId { get; set; }

        [JsonIgnore]

        public virtual ApplicationUser User { get; set; }


    }
}


















