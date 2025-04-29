using SmartBook.Models;
using SmartBook.Handler;
using SmartBook.Services;

namespace SmartBook.Handler
{
    public class BookHandler
    {
        private LibraryService _libraryService = new();
        private List<Book> Books => _libraryService.GetBooks();

        public Book FindByTitle(string title) 
            => Books.FirstOrDefault(c => c.BookInfo?.Title == title) 
            ?? throw new ArgumentNullException("Det finns ingen bok med angiven titel i vår databas.");

        public Book FindByAuthor(string author) 
            => Books.FirstOrDefault(c => c.BookInfo?.Author == author) 
            ?? throw new ArgumentNullException("Det finns ingen bok med angiven titel i vår databas.");

        public void Add(Book book) => Books.Add(book); 
        
        public void Edit(Book book)
        {           
            var targetBook = Books.FirstOrDefault(c => c.Id == book.Id) ?? throw new ArgumentNullException("Den angivna 'Book' returnerar null.");                               
            targetBook.UpdateStatus(book.Status);
            targetBook.UpdateCondition(book.Condition);

            BookInfo bookInfo = book.BookInfo ?? throw new ArgumentNullException("Den angivna bokens 'BookInfo' returnerar null.");
               
            targetBook.BookInfo.UpdateMetadata(bookInfo.ISBN, bookInfo.Title, bookInfo.Author, bookInfo.Genre);                       
        }
        
        public void Remove(Guid id) 
        {                                                 
            var targetBook = Books.FirstOrDefault(c => c.Id == id) ?? throw new ArgumentNullException("Den angivna 'Book' returnerar null.");  
                
            Books.Remove(targetBook);    
        }      
    }
}
