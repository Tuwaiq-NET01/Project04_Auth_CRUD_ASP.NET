using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mininet.Models
{
    public class  RssFeedModel
    {
        public long Id {get; set;}
        [Required]
        public string Url {get; set;}
        public string Title {get; set;}
        public string Link {get;set;}
        public string Description {get;set;}
        public string UserId {get; set;}
        [ForeignKey("UserId")]
        public AppUser User {get; set;}
    }
}