using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WEBv3.Models
{
    public class Booking
    {
        [Key]
        public int id { get; set; }
        public int adult { get; set; }
        public int child { get; set; }
        public int total { get; set; }
        [Column(TypeName = "varchar(50)")]

        public string firstName { get; set; }
        [Column(TypeName = "varchar(50)")]

        public string LastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string email { get; set; }
        [Column(TypeName = "varchar(50)")]
        public bool status { get; set; } = false;

        public int TourId { get; set; }

        [JsonIgnore]

        public virtual Tour Tour { get; set; }






    }
}





