using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Enums.Models;


namespace SmartBook.Models;

public class Book
{
    public Guid Id { get; } = Guid.NewGuid();
    public BookInfo BookInfo { get; private set; }
    public BookStatus Status { get; private set; }
    public BookCondition Condition { get; private set; }
    public DateTime AddedDate { get; } = DateTime.Now;

    public Book()
    {
    }
    public Book(BookInfo bookinfo)
    {
        BookInfo = bookinfo;
    }

    public void UpdateStatus(BookStatus newStatus)
    {
        if (!Enum.IsDefined(newStatus))
            throw new ArgumentException("Bokstatus innehåller felaktivt format.");

        Status = newStatus;   
    }

    public void UpdateCondition(BookCondition newCondition)
    {
        if (!Enum.IsDefined(newCondition))
            throw new ArgumentException("Bokskick innehåller felaktivt format.");

        Condition = newCondition;
    }

    
}
