using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podcast_Website.Models
{
    public class PodcastModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Audio { get; set; }

        public string Podcast_image { get; set; }

        public string Description { get; set; }

        public ProfileModel Profile { get; set; }

        //FK
        public int ProfileId { get; set; }

        public List<PodcastProfileModel> PodcastProfile { get; set; }

        public List<Prodcast_TagModel> Prodcast_Tag { get; set; }

        internal void ToList()
        {
            throw new NotImplementedException();
        }
    }
}
