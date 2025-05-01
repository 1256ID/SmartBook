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
    public Guid UserId { get; set; }
    public Guid CardNumber { get; } = Guid.NewGuid();
    public DateTime IssuedDate { get; } = DateTime.Today;
    public DateTime ExpiryDate { get; } = DateTime.Today.AddYears(1);
    public LibraryCardStatus Status { get; set; }

    public LibraryCard()
    {

    }
    public LibraryCard(Guid userId)
    {
        UserId = userId;
    }

    public void SetStatus(LibraryCardStatus status)
    {
        ValidateStatus(status);
        Status = status;
    }

    private void ValidateStatus(LibraryCardStatus status)
    {
        if (!Enum.IsDefined(status))
            throw new ArgumentException("Lånekorts status innehåller ogiltigt format.", nameof(status));
    }

}
