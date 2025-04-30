using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;
public class Loan
{
    public Guid Id { get; } = Guid.NewGuid();  
    public Guid ISBN { get; private set; }
    public Guid CardNumber { get; private set; }    
    public Guid BookId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime LoanDate { get; private set; } = DateTime.Now;
    public DateTime DueDate { get; private set; }
    public DateTime? ReturnDate { get; private set; } = null;

    public Loan()
    {
        
    }

    public Loan(Guid isbn, Guid cardNumber, Guid bookId, Guid userId)
    {
        ValidateGuid(isbn, nameof(isbn));
        ValidateGuid(cardNumber, nameof(cardNumber));
        ValidateGuid(bookId, nameof(bookId));
        ValidateGuid(userId, nameof(userId));

        ISBN = isbn;
        CardNumber = cardNumber;
        BookId = bookId;
        UserId = userId;
        LoanDate = DateTime.Now;
        DueDate = LoanDate.AddDays(90);
    }

    public void SetReturnDate()
    {
        ReturnDate = DateTime.Now;
    }

    public void ValidateGuid(Guid guid, string paramName)
    {    
        if (guid == Guid.Empty) 
            throw new ArgumentException($"Guid '{paramName}' är tomt.", paramName);
    }

  

}
