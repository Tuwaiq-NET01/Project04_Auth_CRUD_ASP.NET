using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class FeedModel
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        
        //

        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
    }
}