using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FinalProject.Models
{
    public class TvShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Summary { get; set; }
        public int Rating { get; set; }
        public string Poster { get; set; }
        
        // Navigations properties
        public ICollection<FavoriteTvShow> FavoriteTvShow { get; set; }
        
        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}