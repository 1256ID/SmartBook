using SmartBook.Models;
using SmartBook.Services;

namespace SmartBook.Handlers;

public class BookHandler
{
    private LibraryService _libraryService = new();
    private List<Book> Books => _libraryService.GetBooks();

    //////////////////////////////////////////////     GET methods     ////////////////////////////////////////////////////
    
    public Book GetByTitle(string title)
        => Books.FirstOrDefault(c => c.BookInfo.Title.Equals(title))
        ?? throw new ArgumentNullException("Det finns ingen bok med angiven titel i vår databas.");

    public Book GetByAuthor(string author)
        => Books.FirstOrDefault(c => c.BookInfo.Author.Equals(author))
        ?? throw new ArgumentNullException("Det finns ingen bok med angiven titel i vår databas.");

    public Book GetByISBN(Guid isbn)
       => Books.FirstOrDefault(c => c.BookInfo.ISBN.Equals(isbn))
       ?? throw new ArgumentNullException("Det finns ingen bok med angiven titel i vår databas.");


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    ////////////////////////////////////////////////     Other methods     ////////////////////////////////////////////////
    
    public void Add(Book book) => Books.Add(book); 
    
    public void Edit(Book book)
    {           
        var targetBook = Books.FirstOrDefault(c => c.Id.Equals(book.Id)) ?? throw new ArgumentNullException("De valda objektet 'Book' returnerar null.");                               
        targetBook.UpdateStatus(book.Status);
        targetBook.UpdateCondition(book.Condition);

        BookInfo bookInfo = book.BookInfo ?? throw new ArgumentNullException("Den angivna bokens 'BookInfo' returnerar null.");
           
        targetBook.BookInfo.UpdateMetadata(bookInfo.ISBN, bookInfo.Title, bookInfo.Author, bookInfo.Genre);                       
    }
    
    public void Remove(Guid id) 
    {                                                 
        var targetBook = Books.FirstOrDefault(c => c.Id.Equals(id)) ?? throw new ArgumentNullException("De valda objektet 'Book' returnerar null.");  
            
        Books.Remove(targetBook);    
    }

    public bool CheckIfBookInfoExists(Guid isbn)
    {
        if (Guid.Empty == isbn)
            throw new ArgumentException("Guid är tomt.");

        return Books.Exists(c => c.BookInfo.ISBN.Equals(isbn));
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //////////////////////////////////////////////     BookInfo methods     //////////////////////////////////////////////

    public BookInfo GetBookInfoByISBN(Guid isbn)
    {
        if (Guid.Empty == isbn)
            throw new ArgumentException("Guid(ISBN) är tomt.");

        var bookInfo = Books.FirstOrDefault(c => c.BookInfo.ISBN.Equals(isbn)) ?? throw new ArgumentNullException("Den eftersökta 'BookInfo' returnerade null.");
        
        return bookInfo.BookInfo;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////   
    
}
