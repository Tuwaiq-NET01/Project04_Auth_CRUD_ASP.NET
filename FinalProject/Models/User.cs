using Newtonsoft.Json;

namespace FinalProject.Models
{
    public class User
    {
       public int Id { set; get; }
       public string Name { set; get; }
       public string Email { set; get; }
       
       // Navigations properties
       [JsonIgnore] public string Password { set; get; }
       
       public Profile Profile { get; set; }
    }
} 