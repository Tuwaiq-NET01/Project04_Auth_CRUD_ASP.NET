using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class CourseStudentModel
    {
        public int Id { get; set; }

        //
        
        public int CourseModelId { get; set; }
        public CourseModel CourseModel { get; set; }

        //
        
        public int StudentModelId { get; set; }
        public StudentModel StudentModel { get; set; }
    }
}