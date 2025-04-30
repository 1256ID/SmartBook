using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Data;
using SmartBook.Handlers;
using SmartBook.Models;
using SmartBook.Utilities;

namespace SmartBook.Repository
{
    public class LibraryRepository
    {
        private LibraryDataAccess _libraryDataAccess;

        public LibraryRepository(LibraryDataAccess libraryDataAccess)
        {
            _libraryDataAccess = libraryDataAccess;
        }

        public LibraryRepository()
        {

        }

        public List<Book> GetBooks()
        {
            List<Book> bookList = [];

            try
            {
                bookList = _libraryDataAccess.GetAllBooks();
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
                libraryCardList = _libraryDataAccess.GetAllLibraryCards();
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
                loanList = _libraryDataAccess.GetAllLoans();
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
                userList = _libraryDataAccess.GetAllUsers();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return userList;
        }

        public bool InitializeDataBase()
        {
            bool initializedDatabase = false;
            try
            {
                _libraryDataAccess.InitializeDB();
                initializedDatabase = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return initializedDatabase;
        }       

        public bool SaveDataBase()
        {
            bool databaseSavedSuccessfully = false;
            try
            {
                _libraryDataAccess.SaveToDB();
                databaseSavedSuccessfully = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return databaseSavedSuccessfully;
        }
    }
}
