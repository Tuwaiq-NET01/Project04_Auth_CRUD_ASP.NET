using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


namespace MVC_Final.Models
{
    public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetAllBook();
        Book GetBookByID(int book_id);
        void InsertBook(Book book);
        void DeleteBook(int book_id);
        void EditBook(Book book);
        int Save();

    }
}
