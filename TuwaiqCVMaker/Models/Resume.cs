using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json.Serialization;

namespace TuwaiqCVMaker.Models
{
    public class Resume
    {
        public int Id { get; set; }
        [NotNull] public string UserId { get; set; }
        [JsonIgnore] public ApplicationUser User { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Template { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Introduction { get; set; }
        public string JobDescription { get; set; }
        public string PersonalPicture { get; set; }
        public string Education { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}