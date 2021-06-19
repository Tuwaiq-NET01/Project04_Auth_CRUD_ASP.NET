using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Project.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        //Navication property ----- ( one ----> Many )
        public AuthorModel Author { get; set; }
        public int AuthorId { get; set; }


        //-----------------------------------------------

        //Navication property ----- ( one ----> Many )
        public PublisherModel Publisher { get; set; }
        public int PublisherId { get; set; }

        //-----------------------------------------------

        //Many to Many relation ship between BookStore And Book

        public List<BookStore_Book_Model> BookStores_Books { get; set; }
        
    }
}
