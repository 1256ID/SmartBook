using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;
public class Loan
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid ISBN { get; set; }
    public Guid CardNumber { get; set; }
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
    public DateTime LoanDate { get; set; } = DateTime.Now;
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; } = null;

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

    private void ValidateGuid(Guid guid, string paramName)
    {
        if (guid == Guid.Empty)
            throw new ArgumentException($"Guid '{paramName}' är tomt.", paramName);
    }
}
