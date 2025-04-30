using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartBook.Models;

public class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public LibraryCard? LibraryCard { get; private set; } = null;
    public string Name { get; private set; }
    public string Email { get; private set; }   

    public User() 
    { 
    
    }
    public User(string name, string email)
    {
        ValidateName(name);
        ValidateEmail(email);

        Name = name;
        Email = email;
    }

    public void SetName(string name)
    {
        ValidateName(name);
        Name = name;
    }

    public void SetEmail(string email)
    {
        ValidateEmail(email);
        Email = email;
    }

    public void ValidateName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace("Det angivna namnet är tomt eller null.", nameof(name));

        if (name.Length < 2 || name.Length > 50)
            throw new ArgumentException("Det angivna namnet måste vara mellan 2 - 50 tecken.", nameof(name));

        string allowedCharacters = @"^[a-zA-ZåäöÅÄÖ\s\-]+$";
        bool isValidCharSet = name.All(c => allowedCharacters.Contains(c));

        if (!isValidCharSet)
            throw new ArgumentException("Det angivna namnet innehåller ogiltiga tecken.", nameof(name));        
    }

    public string ValidateEmail(string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace("Den angivna mailadressen är tomt eller null.", nameof(email));    

        string allowedPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        bool isValidCharSet = email.All(c => allowedPattern.Contains(c));

        if (!isValidCharSet) 
            throw new ArgumentException("Den angivna mailadressen är i fel format eller innehåller ogiltiga tecken.", nameof(email));

        return email;
    }

    public void AssignLibraryCard(LibraryCard libraryCard)
    {
        ArgumentNullException.ThrowIfNull("Objektet 'LibraryCard' är null.", nameof(libraryCard));
        LibraryCard = libraryCard;
    }
}
