using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for IBookService
/// </summary>
/// 
[ServiceContract]
public interface IBookService
{

    [OperationContract]
    Book AddBook(Book book);

    [OperationContract]
    Book UpdateBook(Book book);

    [OperationContract]
    Book DeleteBook(Book book);

    [OperationContract]
    Book GetBook(int id);

    [OperationContract]
    IEnumerable<Book> GetAllBooks();

    [OperationContract]
    IEnumerable<Book> FindByTitle(string title);
 
}