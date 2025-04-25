using SmartBook.Models;
using SmartBook.Handler;

namespace SmartBook.Handler
{
    public class BookHandler
    {
        private LibraryHandler _libraryHandler = new();
        private List<Book> Books => _libraryHandler.GetAllBooks();

      
        public Book FindByTitle(string title)
        {
            var book = Books.Find(c => c.BookInfo?.Title == title);

            if (string.IsNullOrEmpty(title))          
                throw new ArgumentException("Error: Inmatningen var antingen tom eller null.");
            
            if (book == null)        
                throw new ArgumentNullException("Error: Det finns ingen bok med angiven titel i vår databas.");
            
            return book;
        }

        public Book FindByAuthor(string author)
        {
            var book = Books.Find(c => c.BookInfo?.Author == author);

            if (string.IsNullOrEmpty(author))          
                throw new ArgumentException("Inmatningen var antingen tom eller null.");
            
            if (book == null)
                throw new ArgumentNullException("Det finns ingen bok med angiven titel i vår databas.");
            
            return book;
        }
        public void Add(Book book)
        {
            if (book != null)
            {
                Books.Add(book);
            }

            else
            {
                throw new ArgumentNullException("Boken som du försöker lägga till är null.");
            }
        }

        public void Edit(Book book)
        {
            try
            {
                if (book != null)
                {
                    var targetBook = Books.FirstOrDefault(c => c.Id == book.Id);
                    if (targetBook != null)
                    {
                        bool statusOk = targetBook.UpdateStatus(book.Status);
                        bool conditionOk = targetBook.UpdateCondition(book.Condition);

                        if (!statusOk || !conditionOk)
                            throw new Exception("Det gick inte att uppdatera status eller skick på grund av ogiltig inmatning.");

                        BookInfo? bookInfo = book.BookInfo;

                        if (bookInfo != null)                       
                            targetBook.BookInfo?.UpdateMetadata(bookInfo.Title, bookInfo.Author, bookInfo.Genre);                       
                        else
                            throw new ArgumentNullException("Den angivna bokens 'BookInfo' returnerar null.");



                    }
                }

                else
                {
                    throw new ArgumentNullException("Den angivna boken returnerar null.");
                }
            }

            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex);
            }
           
        }

        public void Remove(Guid id) 
        {
            try
            {
                if (id != Guid.Empty) 
                    throw new ArgumentNullException("Guid är tom.");
                
                var targetBook = Books.FirstOrDefault(c => c.Id == id);

                if (targetBook != null)
                {
                    Books.Remove(targetBook);
                }

                else
                {
                    throw new ArgumentNullException("Den angivna boken existerar inte i vår databas.");
                }
            }

            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex);           
            }

            
        }      
    }
}
