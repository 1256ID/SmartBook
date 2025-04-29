using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Handlers;
using SmartBook.Models;
using SmartBook.Utilities;

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
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
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
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
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
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
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
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return userList;           
        }


        public bool LoadDB()
        {
            bool dbSuccededLoading = false;
            try
            {
                _libraryHandler.LoadFromDB();
                dbSuccededLoading = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return dbSuccededLoading;
        }

        public bool SaveDB()
        {
            bool dbSuccededSaving = false;
            try
            {
                _libraryHandler.SaveToDB();
                dbSuccededSaving = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return dbSuccededSaving;
        }
    }
}
