using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podcast_Website.Models
{
    public class TagModel
    {
        public int Id {  get; set; }
        public string Tag_Name {get; set; }

        public List<Prodcast_TagModel> Prodcast_Tag { get; set; }

    }
}
