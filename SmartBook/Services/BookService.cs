using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Enums.Models;
using SmartBook.Handler;
using System.ComponentModel;
using static System.Reflection.Metadata.BlobBuilder;


namespace SmartBook.Services
{
    public class BookService
    {
        private BookHandler BookHandler = new();


        public Book FindByTitle(string title)
        {
            Book book = new();
            try
            {
                ArgumentException.ThrowIfNullOrEmpty(title, "Inmatningen för titel är antingen tom eller null.");
                book = BookHandler.FindByTitle(title);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }

            return book;
        }

        public Book FindByAuthor(string author)
        {
            Book book = new();

            try
            {
                ArgumentException.ThrowIfNullOrEmpty(author, "Inmatningen för författare är antingen tom eller null.");
                book = BookHandler.FindByAuthor(author);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }

            return book;
        }

        public void AddBook(BookStatus status, BookCondition condition, Guid isbn, string title, string author, string genre)
        {
            try
            {               
                BookInfo bookInfo = new(isbn, title, author, genre);
                Book book = new(bookInfo);
                book.UpdateStatus(status);
                book.UpdateCondition(condition);
                BookHandler.Add(book);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }             
        }

        public void EditBook(Book book)
        {            
            try
            {
                ArgumentNullException.ThrowIfNull(book);
                BookHandler.Edit(book);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }
        }

        public void RemoveBook(Guid id)
        {

            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentException("Guid är tomt.");
                                  
                BookHandler.Remove(id);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }
        }


    }
}
