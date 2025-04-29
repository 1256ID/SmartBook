using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Services;

namespace SmartBook.Handlers
{
    public class UserHandler
    {
        private LibraryService _libraryService = new();
        private List<User> Users => _libraryService.GetUsers();

        public User GetUser(Guid userId) 
            => Users.FirstOrDefault(c => c.Id == userId) 
            ?? throw new ArgumentNullException("'User' objektet returnerade null.");

        public bool Exists(Guid guid)
        {
            return Users.Any(c => c.Id == guid);
        }
    }
}
