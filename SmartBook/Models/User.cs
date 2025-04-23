using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models
{
    class User
    {
        private Guid _id;
        private Guid _libraryCardId;
        private string _name;
        private string _email;

        public Guid LibraryCardId
        {
            get => _libraryCardId;
            private set => _libraryCardId = value;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Email
        {
            get => _email;
            private set => _email = value;
        }

    }
}
