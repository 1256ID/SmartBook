using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;

public class Library
{
    public string Name { get; } = "Ivans Bibliotek";
    public DateTime LastUpdated { get; private set; }

    public List<Book> Books { get; set; } = [];
    public List<LibraryCard> Cards { get; set; } = [];
    public List<Loan> Loans { get; set; } = [];
    public List<User> Users { get; set; } = [];

    public void UpdateLastModified()
    {
        LastUpdated = DateTime.UtcNow;
    }
}

