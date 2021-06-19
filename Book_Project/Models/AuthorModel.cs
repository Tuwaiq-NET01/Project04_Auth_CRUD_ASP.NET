using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Project.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //Relationship : one-To-Many: Author----has many--->Books
        public List<BookModel> Books { get; set; }

        
    }
}
