using System;
namespace eBookshelf.Models
{
    public class NotesModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModified { get; set; }
        public int PageNo { get; set; }

        public EbookModel Ebook { get; set; }
        public int Ebook_id { get; set; }

        public NotesModel()
        {
        }
    }
}
