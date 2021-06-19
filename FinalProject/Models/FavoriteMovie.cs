namespace FinalProject.Models
{
    public class FavoriteMovie
    {
        public int Id { get; set; }
        
        
        // Navigations properties
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}