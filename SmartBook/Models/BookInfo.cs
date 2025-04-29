using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;

public class BookInfo
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid ISBN { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Genre { get; private set; }

    public BookInfo()
    {

    }
    public BookInfo(Guid isbn, string title, string author, string genre)
    {
        if (isbn == Guid.Empty)
            throw new ArgumentException("ISBN numret är tomt.");
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Titel är null eller tom.");
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Författare är null eller tom.");
        if (string.IsNullOrWhiteSpace(genre))
            throw new ArgumentException("Genre är null eller tom.");

        ISBN = isbn;
        Title = title;
        Author = author;
        Genre = genre;
    }

    public void UpdateMetadata(Guid isbn, string newTitle, string newAuthor, string genre)
    {
        if (isbn != Guid.Empty)
        {
            ISBN = isbn;
        }
        if (!string.IsNullOrWhiteSpace(newTitle))
            Title = newTitle;

        if (!string.IsNullOrWhiteSpace(newAuthor))
            Author = newAuthor;

        if (!string.IsNullOrWhiteSpace(genre))
            Genre = genre;
    }

}

