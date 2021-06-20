namespace mininet.Models
{
    public class NoteModel 
    {
        public long Id {get;set;}
        public string Title {get;set;}
        public string Content {get; set;}
        public string UserId {get;set;}
        public AppUser User {get;set;}
    }
}