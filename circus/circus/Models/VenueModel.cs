using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace circus.Models
{
    public class VenueModel
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        //
        public List<ShowModel> Shows { get; set; }
    }
}
