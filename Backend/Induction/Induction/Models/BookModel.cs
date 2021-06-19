using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Induction.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Url]
        public string Url { get; set; }



        //Relationship : One-To-Many: Book => Chapters
        [JsonIgnore]
        public List<ChapterModel> Chapters { get; set; }
    }
}