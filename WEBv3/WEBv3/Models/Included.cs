using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WEBv3.Models
{
    public class Included
    {
        [Key]
        public int IncludedId { get; set; }
        public bool TourGuide { get; set; }
        public bool Transport { get; set; }
        public bool EntiranceFees { get; set; }
        public bool PickUpAndDrop { get; set; }
        public bool Food { get; set; }

        public int TourId { get; set; }

        [JsonIgnore]

        public virtual Tour Tour { get; set; }




    }
}


