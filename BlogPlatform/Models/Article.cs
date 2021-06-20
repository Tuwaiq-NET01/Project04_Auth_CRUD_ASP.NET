using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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
        public string AuthorId { get; set; }
        [JsonIgnore]
        public Person Author { get; set; }

        public string ImageUrl {get;set; }

        public List<ArticleTag> ArticleTags { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}