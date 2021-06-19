using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eBookshelf.Data;

namespace eBookshelf.Models
{
    public class EbookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string CoverImg { get; set; }
        public string ContentUrl { get; set; }
        public DateTime CreationDate { get; set; }

        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }

        List<NotesModel> Notes { get; set; }

        public EbookModel()
        {
        }
    }
}
