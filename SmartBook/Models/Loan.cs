using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;
 class Loan
{
    private int Id;   
    private Guid ISBN;
    private Guid UserId;
    private DateTime LoanDate;
    private DateTime DueDate;
    private DateTime ReturnDate;

    public Loan(int id, Guid iSBN, Guid userId)
    {
        Id = id;
        ISBN = iSBN;
        UserId = userId;
    }
}
