using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;

public class LibraryCard
{
    public Guid Id { get; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    public Guid CardNumber { get; } = Guid.NewGuid();
    public DateTime IssuedDate { get; } = DateTime.Today;
    public DateTime ExpiryDate { get; } = DateTime.Today.AddYears(1);
    private bool IsActive => IsActive == DateTime.Today <= ExpiryDate;
    
}
