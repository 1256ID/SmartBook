using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Utilities;
using SmartBook.Services;
using SmartBook.Data;

namespace SmartBook.Data
{
    public class LibraryDataAccess
    {

        private Library _library;

        private readonly JsonDatabase _db;

        public LibraryDataAccess(JsonDatabase db)
        {
            _db = db;
            _library = _db.Load();           
        }

        // Alla Databas metoder
        public Library GetLibrary() => _library;
        public void InitializeDB() => _db.Initialize();
        public void SaveToDB() => _db.Save(_library);

        // Alla GET metoder

        public List<Book> GetBooks()
        {
            return _library.Books ?? new List<Book>();
        }

        public List<LibraryCard> GetLibraryCards()
        {
            return _library.Cards ?? new List<LibraryCard>();
        }

        public List<Loan> GetLoans()
        {
            return _library.Loans ?? new List<Loan>();
        }

        public List<User> GetUsers()
        {
            return _library.Users ?? new List<User>();
        }


       
    }
}
