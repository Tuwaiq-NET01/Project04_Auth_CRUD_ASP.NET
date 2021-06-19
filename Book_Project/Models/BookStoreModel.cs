using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Project.Models
{
    public class BookStoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //-----------------------------------------------

        //Many to Many relation ship between BookStore And Book

        public List<BookStore_Book_Model> BookStores_Books { get; set; }
    }
}
