using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceGestionBooks.DB;

namespace WCFServiceGestionBooks.BookService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        private ZakDbEntities zakDb;


        public BookService()
        {
            zakDb = new ZakDbEntities();
            zakDb.Configuration.LazyLoadingEnabled = false;
            zakDb.Configuration.ProxyCreationEnabled = false;
        }
        public Book AddBook(Book book)
        {
            Book b = zakDb.Books.Add(book);

            zakDb.SaveChanges();
            return b;
        }

        public Book DeleteBook(int id)
        {

            //if (zakDb.Reservations.Where(r => r.BookId == id).FirstOrDefault() != null)
            //    throw new Exception("Book is reserved, you can't delete it");

            try
            {
                Book b = zakDb.Books.Remove(GetBook(id));
                zakDb.SaveChanges();
                return b;

            }
            catch (Exception e)
            {
                return null; 
            }   
        }

        public Book GetBook(int id)
        {
            return zakDb.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        public List<Book> GetBooks()
        {
            return zakDb.Books.ToList();

        }


        public List<Book> GetBooksByTitle(string title)
        {
           
            return zakDb.Books.Where(b => b.Title.Contains(title)).ToList();
        }

        public Book UpdateBook(Book book)
        {
            zakDb.Entry(book).State = System.Data.Entity.EntityState.Modified;
            zakDb.SaveChanges();
            return book;

        }
    }
}
