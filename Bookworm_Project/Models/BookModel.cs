using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookworm_Project.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Cover { get; set; }
        public string Description { get; set; }

        //Relationship : One-To-Many: Author => Books
        public AuthorModel Author { get; set; }

        //FK
        public int AuthorId { get; set; }

        //Relationship : One-To-Many: Book => Reviews
        public List<ReviewModel> Reviews { get; set; }

    }
}
