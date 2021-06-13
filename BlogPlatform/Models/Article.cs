using System;

namespace BlogPlatform.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        
        public string Title { get; set; }
        
        public string Body { get; set; }
        
        public User Author { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}