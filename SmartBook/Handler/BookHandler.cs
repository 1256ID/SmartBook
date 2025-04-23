using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;

namespace SmartBook.Handler
{
    internal class BookHandler
    {

        public virtual SmartBook.Models.Library Library = new();

        public BookHandler(Library library)
        {
            Library = library;
        }
        public void Get()
        {

        }
        public void Add(BookHandler book)
        {
            
        }

        public void Edit()
        {

        }

        public void Remove() 
        { 
        
        }


        
    }
}
