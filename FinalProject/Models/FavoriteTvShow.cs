namespace FinalProject.Models
{
    public class FavoriteTvShow
    {
        public int Id { get; set; }
        
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        
        public int TvShowId { get; set; }
        public TvShow TvShow { get; set; }
    }
}