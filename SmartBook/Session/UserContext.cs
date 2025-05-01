using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;

namespace SmartBook.Session
{
    public class UserContext
    {
        public User? SelectedUser { get; set; }             

        public bool SelectUser(User user)
        {
            bool selected = false;
            try
            {
                ArgumentNullException.ThrowIfNull(user, "Den valda användaren returnerade null.");
                SelectedUser = user;
                selected = true;
            }

            catch(Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return selected;
        }
    }
}
