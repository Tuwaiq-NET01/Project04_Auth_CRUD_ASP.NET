using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using MVC_Final.Data;
using Microsoft.EntityFrameworkCore;

namespace MVC_Final.Models
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly LibraryContext _db;

        public BookRepository(LibraryContext context)
        {
            _db = context;
        }


        public IEnumerable<Book> GetAllBook()
        {
            return _db.Books.ToList();
        }

        public Book GetBookByID(int book_id)
        {
            return _db.Books.Find(book_id);
        }

        public void InsertBook(Book book)
        {
            _db.Books.Add(book);
        }

        public void DeleteBook(int book_id)
        {
            Book book = _db.Books.Find(book_id);
        }

        public void EditBook(Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
        }
        public int Save()
        {
            return _db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool dis)
        {
            if(!this.disposed)
            {
                if(dis)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
