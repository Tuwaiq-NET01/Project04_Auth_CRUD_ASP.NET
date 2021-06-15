using System.Collections.Generic;

namespace Podcast_Website.ViewModel
{
    public class TagAndPocast
    {
        public string Title { get; set; }
        public string Audio { get; set; }

        public string Podcast_image { get; set; }

        public string Description { get; set; }



        //FK
        public int ProfileId { get; set; }

        public string Tag_Name { get; set; }

        public int Podcast__Id { get; set; }


        public int TagId { get; set; }
    }
}
