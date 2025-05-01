using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Services;
using SmartBook.Session;
using SmartBook.Utilities;

namespace SmartBook.Handlers
{
    public class UserHandler
    {

        private readonly UserService _userService;
        private readonly UserContext _userContext;
        public UserHandler(UserService userService, UserContext userContext) 
        {
            _userService = userService;
            _userContext = userContext;
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

        public User CreateUser(string name, string email)
        {
            User user = new();
            try
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(name);
                ArgumentException.ThrowIfNullOrWhiteSpace(email);
                user = new(name, email);
                _userService.AddUser(user);              
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return user;
        }

       

        public bool EditUser()
        {
            bool isUserEdited = false;


            return isUserEdited;
        }

        public bool RemoveUser(User user)
        {
            bool isUserRemoved = false;

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


            return isUserRemoved;
        }

        public bool UserExists(Guid userId)
        {
            bool doesUserExist = false;
            try
            {
                if (userId == Guid.Empty)
                    throw new ArgumentException
                    (
                        "Guid '" + nameof(userId) + "' är tomt.",
                        nameof(userId)
                    );

                doesUserExist = _userService.Exists(userId);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return doesUserExist;

        }  

        public bool AnyUserExists()
        {
            return _userService.AnyUserExists();
        }

    }
}
