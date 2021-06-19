using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Project.Models
{
    public class BookStore_Book_Model
    {
        //Many to Many relation ship between BookStore And Book

        public BookModel Book { get; set; }
        public int Book_ID { get; set; }

        //-----------------------------------------------

        public BookStoreModel BookStore { get; set; }
        public int BookStore_ID { get; set; }
    }
}
