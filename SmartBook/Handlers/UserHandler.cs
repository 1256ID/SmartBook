using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Services;
using SmartBook.Utilities;

namespace SmartBook.Handlers
{
    public class UserHandler
    {

        private UserService _userService;
        public UserHandler(UserService userService) 
        {
            _userService = userService;
        }

        public User GetUser(Guid userId)
        {
            User user = new();
            try
            {
                if (userId == Guid.Empty)
                    throw new ArgumentException
                    (
                        "Guid '" + nameof(userId) + "' är tomt.",
                        nameof(userId)
                    );

                user = _userService.GetUser(userId) ?? throw new ArgumentNullException("'User' objektet returnerade null.");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return user;
        }

        public List<User> GetUsers()
        {
            List<User> users = [];

            try
            {
                users = _userService.GetUsers();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return users;
        }

        public bool AddUser()
        {
            bool wasAdded = false;


            return wasAdded;
        }

        public bool EditUser()
        {
            bool wasEdited = false;


            return wasEdited;
        }

        public bool RemoveUser(User user)
        {
            bool isRemoved = false;

            try
            {
                ArgumentNullException.ThrowIfNull(user, nameof(user));
                _userService.Remove(user);
            }

            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }


            return isRemoved;
        }

        public bool UserExists(Guid userId)
        {
            bool exists = false;
            try
            {
                if (userId == Guid.Empty)
                    throw new ArgumentException
                    (
                        "Guid '" + nameof(userId) + "' är tomt.",
                        nameof(userId)
                    );

                exists = _userService.Exists(userId);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return exists;

        }

        public bool UserHasLibraryCard(Guid userId)
        {
            bool hasLibraryCard = false;

            try
            {
                if (userId == Guid.Empty)
                    throw new ArgumentException
                   (
                       "Guid '" + nameof(userId) + "' är tomt.",
                       nameof(userId)
                   );

                hasLibraryCard = _userService.UserHasLibraryCard(userId);
            }

            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return hasLibraryCard;
        }

        public bool AnyUserExists()
        {
            return _userService.AnyUserExists();
        }

    }
}
