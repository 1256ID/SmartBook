using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Services;

namespace SmartBook.Handler
{
    public class UserHandler
    {
        private LibraryService _libraryService = new();
        private List<User> Users => _libraryService.GetUsers();

        

    }
}
