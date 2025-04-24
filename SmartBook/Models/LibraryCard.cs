using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;

public class LibraryCard
{
    private Guid _id;
    private Guid _userId;
    private Guid _cardNumber;
    private DateTime _issuedDate;
    private DateTime _expiryDate;
    private bool IsActive => IsActive == DateTime.Now >= _issuedDate && DateTime.Now <= _expiryDate;
   
    public DateTime IssuedDate
    {
        get => _issuedDate;
        private set => _issuedDate = value;
    }

    public DateTime ExpiryDate
    {
        get => _expiryDate;
        private set => _expiryDate = value;
    }

}
