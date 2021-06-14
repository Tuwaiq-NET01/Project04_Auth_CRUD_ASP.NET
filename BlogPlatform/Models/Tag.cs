using System.Collections.Generic;

namespace BlogPlatform.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public List<ArticleTag> ArticleTags { get; set; }
    }
}