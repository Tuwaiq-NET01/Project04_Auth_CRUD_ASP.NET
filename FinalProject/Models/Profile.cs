using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FinalProject.Models
{
    public class Profile
    {
        public int Id { set; get; }
        
        public DateTime JoinedDateTime { get; set; }
        
        
        // Navigations properties
        public int UserId { get; set; }
        public User User { get; set; }
        
        
        
        public ICollection<FavoriteMovie> FavoriteMovie { get; set; }
        
        public ICollection<FavoriteTvShow> FavoriteTvShow { get; set; }
        
        public ICollection<Movie> Movie { get; set; }
        
        public ICollection<TvShow> TvShow { get; set; }
    }
}