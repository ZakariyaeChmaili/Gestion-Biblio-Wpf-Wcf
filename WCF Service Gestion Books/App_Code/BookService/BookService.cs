
using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookService
/// </summary>
public class BookService : IBookService
{
    public BookService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Book AddBook(Book book)
    {
        throw new NotImplementedException();
    }

    public Book DeleteBook(Book book)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> FindByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetAllBooks()
    {
        throw new NotImplementedException();
    }

    public Book GetBook(int id)
    {
        throw new NotImplementedException();
    }

    public Book UpdateBook(Book book)
    {
        throw new NotImplementedException();
    }
}