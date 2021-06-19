using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Induction.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        [JsonIgnore]
        public string Password { get; set;  }


        

        //Relationship : One-To-Many: User => Motivations
        [JsonIgnore]
        public List<MotivationModel> Motivations { get; set; }
        //Relationship : One-To-Many: User => Facts
        [JsonIgnore]
        public List<FactModel> Facts { get; set; }
        
    }
    
  
}