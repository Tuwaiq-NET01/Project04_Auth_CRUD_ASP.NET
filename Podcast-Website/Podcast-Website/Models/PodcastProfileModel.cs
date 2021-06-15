using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Podcast_Website.Models
{
    public class PodcastProfileModel
    {
        public int Id { get; set; }

        public double Score { get; set; }


        public int Profile_Id { get; set; }
        [ForeignKey("Profile_Id")]
        public ProfileModel Profile { get; set; }

        public int PodcastId { get; set; }
        [ForeignKey("PodcastId")]
        public PodcastModel Podcast { get; set; }




    }
}
