using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace circus.Models
{
    public class ShowModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //nav
        public VenueModel Venue { get; set; }
        public int VenueId { get; set; }
        public PerformerModel Performer { get; set; }
        public int PerformerId { get; set; }
    }
}
