using SmartBook.Models;
using SmartBook.Enums.Models;
using SmartBook.Handlers;
using SmartBook.Utilities;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using static System.Reflection.Metadata.BlobBuilder;
using SmartBook.Data;
using SmartBook.Repository;


namespace SmartBook.Services
{
    public class BookService
    {

        private readonly LibraryRepository _repository;
        private readonly string bookIsNull = "Objektet 'Book' med angiven parameter returnerade null.";

        public BookService(LibraryRepository repository)
        {
            _repository = repository;
        }

        //////////////////////////////////////////////     GET methods     ////////////////////////////////////////////////////

        public Book GetById(Guid bookId)
            => _repository.GetBooks().FirstOrDefault(c => c.Id == bookId)
            ?? throw new InvalidOperationException("Ingen bok med angivet " + nameof(bookId) + " hittades.");
        public Book GetByTitle(string title)
            => _repository.GetBooks().FirstOrDefault(c => c.BookInfo.Title.Equals(title))
            ?? throw new InvalidOperationException("Ingen bok med angivet " + nameof(title) + " hittades.");
        public Book GetByAuthor(string author)
            => _repository.GetBooks().FirstOrDefault(c => c.BookInfo.Author.Equals(author))
            ?? throw new InvalidOperationException("Ingen bok med angivet " + nameof(author) + " hittades.");
        public Book GetByISBN(Guid isbn)
           => _repository.GetBooks().FirstOrDefault(c => c.BookInfo.ISBN.Equals(isbn))
           ?? throw new InvalidOperationException("Ingen bok med angivet " + nameof(isbn) + " hittades.");

        public List<Book> GetBooks() => _repository.GetBooks();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////     GET ALL methods     ///////////////////////////////////////////////////
        public List<Book> GetBooksByTitle(string title)
        {
            return [.. _repository
                .GetBooks()
                .Where(b => b.BookInfo.Title.Equals(title))];
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return [.. _repository
                .GetBooks()
                .Where(b => b.BookInfo.Author.Equals(author))];
        }

        ////////////////////////////////////////////////     Other methods     ////////////////////////////////////////////////

        public void Add(Book book) => _repository.Add(book);

        public Book Edit(Book book)
        {
            var targetBook
                = _repository.GetBooks().FirstOrDefault(c => c.Id.Equals(book.Id))
                ?? throw new ArgumentNullException
                    (
                        nameof(book),
                        "Det angivna objektet är null och kan inte uppdateras."
                    );

            targetBook.SetStatus(book.Status);
            targetBook.SetConditon(book.Condition);

            BookInfo bookInfo
                = book.BookInfo
                ?? throw new ArgumentNullException
                    (
                        nameof(book),
                        nameof(book.BookInfo) + " returnerade null."
                    );

            targetBook.BookInfo.SetTitle(bookInfo.Title);
            targetBook.BookInfo.SetAuthor(bookInfo.Author);
            targetBook.BookInfo.SetGenre(bookInfo.Genre);

            return targetBook;
        }

        public void Remove(Guid isbn)
        {
            var targetBook
                = _repository.GetBooks().FirstOrDefault(c => c.Id.Equals(isbn))
                ?? throw new ArgumentNullException
                    (
                        nameof(isbn),
                        bookIsNull
                    );

            _repository.Remove(targetBook);
        }

        public bool BookExists(Guid isbn)
        {
            return _repository.GetBooks().Exists(c => c.BookInfo.ISBN.Equals(isbn));
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////     BookInfo methods     //////////////////////////////////////////////

        public BookInfo GetBookInfoByISBN(Guid isbn)
        {
            var bookInfo
                = _repository.GetBooks().FirstOrDefault(c => c.BookInfo.ISBN.Equals(isbn))
                ?? throw new ArgumentNullException
                    (
                        nameof(isbn),
                        "Objektet 'BookInfo' innehållandes angivet '" + nameof(isbn) + "' returnerade null"
                    );

            return bookInfo.BookInfo;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
    }
}
