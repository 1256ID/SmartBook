using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;
 class Loan
{
    private Guid _id;   
    private Guid _isbn;
    private Guid _userId;
    private DateTime _loanDate;
    private DateTime _dueDate;
    private DateTime _returnDate;

    public DateTime LoanDate
    {
        get => _loanDate;
        private set => _loanDate = value;
    }

    public DateTime DueDate
    {
        get => _dueDate;
        private set => _dueDate = value;
    }

    public DateTime ReturnDate
    {
        get => _returnDate;
        private set => _returnDate = value;
    }
}
