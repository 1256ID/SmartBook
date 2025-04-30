using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;

public class Library
{
    public string Name { get; } = "Ivans Bibliotek";
    private List<Book> _books;
    private List<LibraryCard> _cards;
    private List<Loan> _loans;
    private List<User> _users;
    public DateTime LastUpdated { get; private set; }

    public Library()
    {
        _books = [];
        _cards = [];    
        _loans = [];
        _users = [];
    }

    public List<Book> Books
    {
        get => _books;  
        private set => _books = value;
    }

    public List<LibraryCard> Cards
    {
        get => _cards;
        private set => _cards = value;
    }

    public List<Loan> Loans
    {
        get => _loans;
        private set => _loans = value;
    }

    public List<User> Users
    {
        get => _users;
        private set => _users = value;
    }

    public void UpdateLastModified()
    {
        LastUpdated = DateTime.UtcNow;
    }
}
