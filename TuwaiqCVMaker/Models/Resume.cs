using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TuwaiqCVMaker.Models
{
    public class Resume
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Template { get; set; }
        [Required] public string UserId { get; set; }
        [JsonIgnore] public ApplicationUser User { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Introduction { get; set; }
        public string Education { get; set; }
        public ICollection<Skill> Skills { get; set; }

        public void Copy(Resume resume)
        {
            this.Name = resume.Name;
            this.Template = resume.Template;
            this.Email = resume.Email;
            this.Phone = resume.Phone;
            this.Introduction = resume.Introduction;
            this.Education = resume.Education;
            this.Skills = resume.Skills;
        }
    }
}