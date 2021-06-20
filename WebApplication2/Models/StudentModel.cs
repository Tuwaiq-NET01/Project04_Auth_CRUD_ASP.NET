using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        
        //

        public IList<FeedModel> FeedModels { get; set; }
        
        //

        public List<CourseStudentModel> CourseStudentModels { get; set; }
    }
}