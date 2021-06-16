using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Final.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Availabe { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

    }
}
