using SmartBook.Data;
using SmartBook.Enums.Models;
using SmartBook.Models;
using SmartBook.Services;
using SmartBook.Session;
using SmartBook.Utilities;

namespace SmartBook.Handlers;

public class BookHandler
{
    private readonly BookService _bookService;
    private readonly UserContext _userContext;
    public BookHandler(BookService bookService, UserContext userContext)
    {
        _bookService = bookService;
        _userContext = userContext;
    }


    //////////////////////////////////////////////     GET methods     ////////////////////////////////////////////////////

    public Book GetBookById(Guid bookId)
    {
        Book book = new();
        try
        {
            if (bookId == Guid.Empty)
                throw new ArgumentException
                (
                    "Guid '" + nameof(bookId) + "' är tomt.",
                    nameof(bookId)
                );

            book = _bookService.GetById(bookId);
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return book;
    }

    public Book GetBookByTitle(string title)
    {
        Book book = new();
        try
        {
            ArgumentException.ThrowIfNullOrEmpty
            (
                nameof(title),
                nameof(title) + " är antingen tomt eller null."
            );

            book = _bookService.GetByTitle(title);
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return book;
    }

    public Book GetBookByAuthor(string author)
    {
        Book book = new();

        try
        {
            ArgumentException.ThrowIfNullOrEmpty
            (
                nameof(author),
                nameof(author) + " är antingen tomt eller null."
            );

            book = _bookService.GetByAuthor(author);
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return book;
    }

    public Book GetBookByISBN(Guid isbn)
    {
        Book book = new();

        try
        {
            if (isbn == Guid.Empty)
                throw new ArgumentException
                (
                    "Guid '" + nameof(isbn) + "' är tomt.",
                    nameof(isbn)
                );


            book = _bookService.GetByISBN(isbn);
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return book;
    }


    public List<Book> GetBooks()
    {
        List<Book> books = [];

        try
        {
            books = _bookService.GetBooks();
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return books;
    }

    public List<Book> GetBooksByTitle(string title)
    {
        List<Book> books = [];

        try
        {
            if (string.IsNullOrWhiteSpace(title))
                return new List<Book>();
            books = _bookService.GetBooksByTitle(title);
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return books;
        
    }

    public List<Book> GetBooksByAuthor(string author)
    {
        List<Book> books = [];

        try
        {
            if (string.IsNullOrWhiteSpace(author))
                return new List<Book>();
            books = _bookService.GetBooksByAuthor(author);
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return books;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    ////////////////////////////////////////////////     Other methods     ////////////////////////////////////////////////

    public bool AddBook(BookStatus status, BookCondition condition, string title, string author, BookGenre genre)
    {
        bool bookHasBeenAdded = false;

        try
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException(nameof(title) + " är tomt eller null", title);

            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException(nameof(author) + " är tomt eller null", author);

            BookInfo bookInfo = new(title, author);
            bookInfo.SetGenre(genre);
            Book book = new(bookInfo);
            book.SetStatus(status);
            book.SetConditon(condition);

            _bookService.Add(book);
            bookHasBeenAdded = true;
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return bookHasBeenAdded;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public bool EditBook(Book book)
    {
        bool bookHasBeenEdited = false;
        try
        {
            ArgumentNullException.ThrowIfNull
            (
                nameof(book) + " returnerade null.",
                nameof(book)
            );

            _bookService.Edit(book);
            bookHasBeenEdited = true;

        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return bookHasBeenEdited;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public bool RemoveBook(Guid bookId)
    {
        bool bookHasBeenRemoved = false;
        try
        {
            if (bookId == Guid.Empty)
                throw new ArgumentException
                (
                    "Guid '" + nameof(bookId) + "' är tomt.",
                    nameof(bookId)
                );

            _bookService.Remove(bookId);
            bookHasBeenRemoved = true;
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return bookHasBeenRemoved;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public bool BookExists(Guid bookId)
    {
        bool exists = false;
        try
        {
            if (bookId == Guid.Empty)
                throw new ArgumentException
                (
                    "Guid '" + nameof(bookId) + "' är tomt.",
                    nameof(bookId)
                );

            exists = _bookService.BookExists(bookId);
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return exists;
    }

    public BookInfo GetBookInfoByISBN(Guid bookId)
    {
        BookInfo bookInfo = new();
        try
        {
            if (Guid.Empty == bookId)
                throw new InvalidOperationException("Ingen bok med angivet " + nameof(bookId) + " hittades.");

            bookInfo = _bookService.GetBookInfoByISBN(bookId);
        }

        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return bookInfo;
    }

}
