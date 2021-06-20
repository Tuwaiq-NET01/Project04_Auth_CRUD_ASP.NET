using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class InstructorModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Information { get; set; }
        
        //
        
        [JsonIgnore]
        public IList<CourseModel> Courses { get; set; }
    }
}