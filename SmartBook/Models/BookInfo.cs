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

    public BookInfo(string title, string author, string genre)
    {
        Title = title;
        Author = author;
        Genre = genre;
    }

    public void UpdateMetadata(string newTitle, string newAuthor, string genre)
    {
        if (!string.IsNullOrWhiteSpace(newTitle))
            Title = newTitle;

        if (!string.IsNullOrWhiteSpace(newAuthor))
            Author = newAuthor;

        if (!string.IsNullOrWhiteSpace(genre))
            Genre = genre;
    }

}

