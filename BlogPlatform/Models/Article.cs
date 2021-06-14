using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
        
        public Person Author { get; set; }

        public List<ArticleTag> ArticleTags { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}