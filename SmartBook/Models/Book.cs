using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace SmartBook.Models;

public class Book
{
    public Guid Id { get; }
    public Guid BookInfoId { get; private set; }
    public BookStatus Status { get; private set; }
    public BookCondition Condition { get; private set; }
    public DateTime AddedDate { get; } = DateTime.Now;

    public bool UpdateStatus(BookStatus newStatus)
    {
        if (!Enum.IsDefined(newStatus))
            return false;

        Status = newStatus;
        return true;
    }

    public enum BookStatus
    {
        Available,
        Reserved,
        Loaned,
        Missing
    }

    public static string GetSwedishName(BookStatus status)
    {
        return status switch
        {
            BookStatus.Available => "Tillgänglig",
            BookStatus.Reserved => "Reserverad",
            BookStatus.Loaned => "Utlånad",
            BookStatus.Missing => "Borttappad",
            _ => "Okänt"
        };
    }

    public bool UpdateCondition(BookCondition newCondition)
    {
        if (!Enum.IsDefined(newCondition))
            return false;

        Condition = newCondition;
        return true;
    }

    public enum BookCondition
    {
        New,
        Good,
        Fair,
        Poor,
        Damaged
    }

    public static string GetSwedishName(BookCondition condition)
    {
        return condition switch
        {
            BookCondition.New => "Ny",
            BookCondition.Good => "Bra",
            BookCondition.Fair => "Okej",
            BookCondition.Poor => "Dålig",
            BookCondition.Damaged => "Skadad",
            _ => "Okänt"
        };
    }

    public BookInfo? BookInfo { get; set; }
}
