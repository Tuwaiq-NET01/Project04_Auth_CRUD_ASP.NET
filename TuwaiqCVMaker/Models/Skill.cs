using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TuwaiqCVMaker.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int ResumeId { get; set; }
        [JsonIgnore] public Resume Resume { get; set; }
    }
}