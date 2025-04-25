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
    public Guid UserId { get; private set; }
    public DateTime LoanDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime ReturnDate { get; private set; } 
}
