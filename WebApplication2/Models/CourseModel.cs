using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string LevelOfDifficulty { get; set; }
        public int Rating { get; set; }
        
        //

        public int InstructorId { get; set; }
        public InstructorModel Instructor { get; set; }
        
        //

        [JsonIgnore]
        public List<CourseStudentModel> CourseStudentModels { get; set; }
    }
}