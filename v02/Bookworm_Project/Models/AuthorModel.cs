using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookworm_Project.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string Avatar { get; set; }

        //Relationship : One-To-Many: Author => Books   
        public List<BookModel> Books { get; set; }
    }
}   
