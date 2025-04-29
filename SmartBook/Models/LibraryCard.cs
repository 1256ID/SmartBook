using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Enums.Models;

namespace SmartBook.Models;

public class LibraryCard
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    public Guid CardNumber { get; } = Guid.NewGuid();
    public DateTime IssuedDate { get; } = DateTime.Today;
    public DateTime ExpiryDate { get; } = DateTime.Today.AddYears(1);
    public LibraryCardStatus Status { get; private set; }

    public LibraryCard()
    {

    }
    public LibraryCard (Guid userId)
    {        
        UserId = userId;
    }

    public void UpdateStatus(LibraryCardStatus newStatus)
    {
        if (!Enum.IsDefined(newStatus))
            throw new ArgumentException("Lånekorts status innehåller ogiltigt format.");

        Status = newStatus;        
    }

}
