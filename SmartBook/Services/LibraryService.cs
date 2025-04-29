using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Handler;
using SmartBook.Models;

namespace SmartBook.Services
{
    public class LibraryService
    {
        private LibraryHandler _libraryHandler = new();

        public List<Book> GetBooks()
        {
            List<Book> bookList = [];

            try
            {
                bookList = _libraryHandler.GetAllBooks();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }

            return bookList;
        }

        public List<LibraryCard> GetLibraryCards()
        {
            List<LibraryCard> libraryCardList = [];

            try
            {
                libraryCardList = _libraryHandler.GetAllLibraryCards();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }

            return libraryCardList;
           
        }

        public List<Loan> GetLoans()
        {
            List<Loan> loanList = [];

            try
            {
                loanList = _libraryHandler.GetAllLoans();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }

            return loanList;          
        }

        public List<User> GetUsers()
        {
            List<User> userList = [];

            try
            {
                userList = _libraryHandler.GetAllUsers();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }

            return userList;           
        }


        public void LoadDB()
        {
            try
            {
                _libraryHandler.LoadFromDB();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }
        }

        public void SaveDB()
        {           
            try
            {
                _libraryHandler.SaveToDB();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }
        }
    }
}
