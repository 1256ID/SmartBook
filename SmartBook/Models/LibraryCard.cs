using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models
{
    internal class LibraryCard
    {
        private Guid Id;
        private Guid UserId;
        private Guid CardNumber;
        private DateTime IssuedDate;
        private DateTime ExpiryDate;
        private bool IsActive;      
    }
}
