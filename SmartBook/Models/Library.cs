using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models
{
    class Library
    {
        private string Name = "Ivans Bibliotek";
        private List<Book> books = [];
        private List<LibraryCard> cards = [];
        private List<Loan> loans = [];
        private DateTime LastUpdated;
    }
}
