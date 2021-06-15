using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podcast_Website.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Item
    {
        public object id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public string guid { get; set; }
        public int datePublished { get; set; }
        public int dateCrawled { get; set; }
        public string enclosureUrl { get; set; }
        public string enclosureType { get; set; }
        public int enclosureLength { get; set; }
        public int? duration { get; set; }
        public int @explicit { get; set; }
        public int? episode { get; set; }
        public string episodeType { get; set; }
        public int season { get; set; }
        public string image { get; set; }
        public int? feedItunesId { get; set; }
        public string feedImage { get; set; }
        public int feedId { get; set; }
        public string feedUrl { get; set; }
        public string feedAuthor { get; set; }
        public string feedTitle { get; set; }
        public string feedLanguage { get; set; }
        public object chaptersUrl { get; set; }
        public object transcriptUrl { get; set; }
    }

    public class Root
    {
        public string status { get; set; }
        public List<Item> items { get; set; }
        public int count { get; set; }
        public string query { get; set; }
        public string description { get; set; }
    }



}
