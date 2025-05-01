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

    public void SetStatus(BookStatus status)
    {
        ValidateStatus(status);
        Status = status;
    }

    public void SetConditon(BookCondition condition)
    {        
        ValidateConditon(condition);
        Condition = condition;
    }

    private void ValidateStatus(BookStatus status)
    {
        if (!Enum.IsDefined(status))
            throw new ArgumentException("Bokstatus innehåller felaktivt format.", nameof(status));  
    }

    private void ValidateConditon(BookCondition condition)
    {
        if (!Enum.IsDefined(condition))
            throw new ArgumentException("Bokskick innehåller felaktivt format.", nameof(condition));       
    }

    
}
