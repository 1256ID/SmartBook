using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models
{
    class User
    {
        public required Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
