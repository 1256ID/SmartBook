using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;

public class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public LibraryCard? LibraryCard { get; private set; }
    public string? Name { get; private set; }
    public string? Email { get; private set; }   
}
