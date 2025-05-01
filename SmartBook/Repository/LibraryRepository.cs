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
        private Library _library;

        public LibraryRepository(LibraryDataAccess libraryDataAccess)
        {
            _libraryDataAccess = libraryDataAccess;
            _library = _libraryDataAccess.Load();
        }


        // Alla GET metoder

        public List<Book> GetBooks() =>_library.Books ?? [];
        public List<LibraryCard> GetLibraryCards() => _library.Cards ?? [];
        public List<Loan> GetLoans() => _library.Loans ?? [];
        public List<User> GetUsers() => _library.Users ?? [];
        

        // Alla ADD metoder

        public void Add(Book book) 
        {
            _library.Books.Add(book);
            _library.UpdateLastModified();
            _libraryDataAccess.Save(_library);

        } 
        public void Add(LibraryCard card)
        {
            _library.Cards.Add(card);
            _library.UpdateLastModified();
            _libraryDataAccess.Save(_library);
        }
        public void Add(Loan loan)
        {
            _library.Loans.Add(loan);
            _library.UpdateLastModified();
            _libraryDataAccess.Save(_library);
        }
        public void Add(User user)
        {
            _library.Users.Add(user);
            _library.UpdateLastModified();
            _libraryDataAccess.Save(_library);
        }

        // Alla REMOVE metoder

        public void Remove(Book book)
        {
            _library.Books.Remove(book);
            _library.UpdateLastModified();
            _libraryDataAccess.Save(_library);
        }
        public void Remove(LibraryCard card)
        {
            _library.Cards.Remove(card);
            _library.UpdateLastModified();
            _libraryDataAccess.Save(_library);
        }
        public void Remove(Loan loan)
        {
            _library.Loans.Remove(loan);
            _library.UpdateLastModified();
            _libraryDataAccess.Save(_library);

        }
        public void Remove(User user)
        {
            _library.Users.Remove(user);
            _library.UpdateLastModified();
            _libraryDataAccess.Save(_library);               
        }
    }
}
