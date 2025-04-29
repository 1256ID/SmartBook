using SmartBook.Models;
using SmartBook.Enums.Models;
using SmartBook.Handlers;
using SmartBook.Utilities;


namespace SmartBook.Services
{
    public class BookService
    {
        private BookHandler _bookHandler = new();



        //////////////////////////////////////////////     GET methods     ////////////////////////////////////////////////////

        public Book GetBookById(Guid bookId)
        {
            Book book = new();
            try
            {
                if (Guid.Empty == bookId)
                    throw new ArgumentException("Guid(bookId) är tomt.");

                book = _bookHandler.GetById(bookId);
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
                ArgumentException.ThrowIfNullOrEmpty(title, "Inmatningen för titel är antingen tom eller null.");
                book = _bookHandler.GetByTitle(title);
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
                ArgumentException.ThrowIfNullOrEmpty(author, "Inmatningen för författare är antingen tom eller null.");
                book = _bookHandler.GetByAuthor(author);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

                return book;          
        }

        public Book GetBookByISBN(Guid input)
        {
            Book book = new();

            try
            {
                if (input.Equals(Guid.Empty))
                    throw new ArgumentException("Guid(ISBN) är tomt.");

                               
                book = _bookHandler.GetByISBN(input);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return book;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        ////////////////////////////////////////////////     Other methods     ////////////////////////////////////////////////

        public bool AddBook(BookStatus status, BookCondition condition, Guid isbn, string title, string author, string genre)
        {
            bool bookHasBeenAdded = false;

            try
            {
                BookInfo bookInfo;
                
                if (_bookHandler.CheckIfBookInfoExists(isbn))
                {
                    bookInfo = _bookHandler.GetBookInfoByISBN(isbn);
                }

                else
                {
                    bookInfo = new(isbn, title, author, genre);
                }

                Book book = new(bookInfo);
                book.UpdateStatus(status);
                book.UpdateCondition(condition);

                _bookHandler.Add(book);
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
                ArgumentNullException.ThrowIfNull(book);
                _bookHandler.Edit(book);
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

        public bool RemoveBook(Guid id)
        {
            bool bookHasBeenRemoved = false;
            try
            {
                if (id.Equals(Guid.Empty))
                    throw new ArgumentException("Guid(BookId) är tomt.");
                                  
                _bookHandler.Remove(id);
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


    }
}
