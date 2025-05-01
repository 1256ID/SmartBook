using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Enums.Models;

namespace SmartBook.Models;

public class BookInfo
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid ISBN { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public string Author { get; private set; }
    public BookGenre Genre { get; private set; }

    public BookInfo()
    {

    }
    public BookInfo(string title, string author)
    {
        ValidateTitle(title);
        ValidateAuthor(author);
               
        Title = title;
        Author = author;
    }
   

    public void SetTitle(string title)
    {
        ValidateTitle(title);
        Title = title;
    }

    public void SetAuthor(string author)
    {
        ValidateAuthor(author);
        Author = author;
    }

    public void SetGenre(BookGenre genre)
    {
        ValidateGenre(genre);
        Genre = genre;
    }


    //////////////////////////////////      Validerings metoder      //////////////////////////////////

    private void ValidateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Titel är null eller tom.", nameof(title));

        string allowedCharacters = @"^[a-zA-ZåäöÅÄÖ\s\-]+$";
        bool isValidCharSet = title.All(c => allowedCharacters.Contains(c));

        if (!isValidCharSet)
            throw new ArgumentException("Den angivna titeln innehåller ogiltiga tecken.", nameof(title));

    }
    private void ValidateAuthor(string author)
    {      
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Författare är null eller tom.", nameof(author));
    }

    private void ValidateGenre(BookGenre genre)
    {
        if (!Enum.IsDefined(genre))
            throw new ArgumentException("Bokstatus innehåller felaktivt format.", nameof(genre));
    }
}

