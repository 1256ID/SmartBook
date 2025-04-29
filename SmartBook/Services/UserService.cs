using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Handlers;
using SmartBook.Models;
using SmartBook.Utilities;

namespace SmartBook.Services;

public class UserService
{
    private UserHandler _userHandler = new();
    public User GetUser(Guid userId)
    {
        User user = new();
        try
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Guid (UserId) är tomt.");

            user = _userHandler.GetUser(userId) ?? throw new ArgumentNullException("'User' objektet returnerade null.");
        }

        catch (Exception ex) 
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();       
        }

        return user;
    }

    public bool CheckIfUserExists(Guid userId)
    {
        bool result = false;
        try
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("Guid (userId) är tomt.");

            result = _userHandler.Exists(userId);
        }

        catch (Exception ex) 
        {
            Console.WriteLine("Error: " + ex.Message);
            AppTools.WaitForEnterKey();
        }

        return result;
        
    }
}
