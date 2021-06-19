using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Induction.Models
{
    public class ChapterModel
    {
        public int Id { get; set; }
        public string Title { get; set; }



        //Relationship : One-To-Many: Book => Chapters
        [JsonIgnore]
        public BookModel Book { get; set; }
        //FK 
        public int BookId { get; set; }


        //Relationship : One-To-Many: Chapter => ChapterChunks
        [JsonIgnore]
        public List<ChapterChunkModel> ChapterChuncks { get; set; }
        


    }
}