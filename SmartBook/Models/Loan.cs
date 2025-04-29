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

    public Loan(Guid iSBN, Guid cardNumber, Guid bookId, Guid userId)
    {       
        ISBN = iSBN;
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

}
