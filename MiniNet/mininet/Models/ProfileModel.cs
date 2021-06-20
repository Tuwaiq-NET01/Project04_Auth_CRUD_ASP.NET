namespace mininet.Models
{
    public class ProfileModel
    {
        public long Id {get;set;}
        public string Name {get;set;}
        public string Img {get;set;}
        public string UserId {get;set;}
        public AppUser User {get;set;}
    }
}