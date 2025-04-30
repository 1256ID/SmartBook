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

        public List<Book> GetAllBooks()
        {
            return _library.Books ?? throw new ArgumentNullException("Books", "Listan med böcker är null.");
        }

        public List<LibraryCard> GetAllLibraryCards()
        {
            return _library.Cards ?? throw new ArgumentNullException("LibraryCards", "Listan med lånekort är null.");
        }

        public List<Loan> GetAllLoans()
        {
            return _library.Loans ?? throw new ArgumentNullException("Loans", "Listan med boklån är null.");
        }

        public List<User> GetAllUsers()
        {
            return _library.Users ?? throw new ArgumentNullException("Users", "Listan med användare är null.");
        }          
    }
}
