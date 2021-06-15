using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podcast_Website.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Background_Image { get; set; }

        public IdentityUser User { get; set; }
        // [ForeignKey("Id")]
        public string UserId { get; set; }

        public List<PodcastModel> Podcasts { get; set; }

        public List<PodcastProfileModel> PodcastProfile { get; set; }






    }
}
