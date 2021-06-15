using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Podcast_Website.Models
{
    public class Prodcast_TagModel
    {
        public int Id { get; set; }

        public int Podcast__Id { get; set; }
        [ForeignKey("Podcast__Id")]
        public PodcastModel Podcast { get; set; }

        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public TagModel Tag { get; set; }
    }
}
