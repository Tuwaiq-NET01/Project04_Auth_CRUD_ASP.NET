using System.ComponentModel.DataAnnotations;
using AppStore.Data;

namespace AppStore.Models
{
    public class RatingModel
    {
        [Key]
        public int Id { get; set; }
        public float Rating { get; set; }
        public string Review { get; set; }
        
        public AppModel App { get; set; }
        public int AppId { get; set; }
        
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}