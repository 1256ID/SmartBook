using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;

namespace SmartBook.Handler
{
    public class LibraryHandler
    {
        private Library _library = new();
        
        public List<Book> GetAllBooks()
        { 
            return _library.Books ?? throw new ArgumentNullException("Listan med böcker är null.");
        }

        public List<LibraryCard> GetAllLibraryCards()
        {
            return _library.Cards ?? throw new ArgumentNullException("Listan med lånekort är null.");
        }

        public List<Loan> GetAllLoans()
        {
            return _library.Loans ?? throw new ArgumentNullException("Listan med boklån är null.");
        }

        public List<User> GetAllUsers() 
        {
            return _library.Users ?? throw new ArgumentNullException("Listan med användare är null.");
        }
    }
}
