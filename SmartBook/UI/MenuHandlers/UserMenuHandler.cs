using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Handlers;
using SmartBook.Models;
using SmartBook.UI.FormatTools;
using SmartBook.Session;
using System.Reflection;
using System.ComponentModel.Design;
using SmartBook.Utilities;

namespace SmartBook.UI.MenuHandlers
{
    public class UserMenuHandler
    {
        private readonly BookHandler _bookHandler;
        private readonly LibraryCardHandler _libraryCardHandler;
        private readonly LoanHandler _loanHandler;
        private readonly UserHandler _userHandler;

        private readonly UserContext _userContext;
        public UserMenuHandler(BookHandler bookHandler, LibraryCardHandler libraryCardHandler, LoanHandler loanHandler, UserHandler userHandler, UserContext userContext)
        {
            _bookHandler = bookHandler;
            _libraryCardHandler = libraryCardHandler;
            _loanHandler = loanHandler;
            _userHandler = userHandler;
            _userContext = userContext;
        }
        public void SelectOrCreateUser()
        {
            if (_userHandler.AnyUserExists())
            {
                List<User> users = _userHandler.GetUsers();
                string[] userArray = new string[users.Count];
                int index = 0;
                foreach (User user in users)
                {
                    userArray[index++] = UserFormat.FormatRow(user);
                }

                index = 0;

                index = Menu.Display
                (
                    "Välj en användare.\n",
                    userArray,
                    index
                );

                _userContext.SelectUser(users[index]);
            }

            else
            {
                bool userIsCreated = false;
                do
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Var vänlig och skapa en ny användare.\n");
                        Console.Write("Ange namn: ");
                        string? name = Console.ReadLine();

                        if (string.IsNullOrEmpty(name))
                        {
                            Console.Clear();
                            Console.WriteLine("Namnet måste innehålla mellan 2-50 tecken, bindesträck är det enda tillåtna specialtecknet.\nVar vänlig och försök igen.");
                            AppTools.WaitForEnterKey();

                        }

                        Console.Clear();
                        Console.WriteLine("Tillåtet format: namn@domän.se");
                        Console.WriteLine("Använd ett mellanslag istället för @");
                        Console.Write("\nAnge email: ");
                        string? email = Console.ReadLine()?.Replace(" ", "@"); ;

                        if (string.IsNullOrEmpty(email))
                        {
                            Console.Clear();
                            Console.WriteLine("Ogiltigt format, försök igen.");
                            AppTools.WaitForEnterKey();
                        }



                        if (name != null && email != null)
                        {
                            (User user, userIsCreated) = _userHandler.CreateUser(name, email);
                            if (userIsCreated) 
                                _userContext.SelectUser(user);

                            else
                            {
                                Console.WriteLine("Det gick inte att skapa användarkontot, var vänlig och försök igen.");
                                AppTools.WaitForEnterKey();
                            }
                            
                        }

                    }

                    catch
                    {
                        Console.WriteLine("Ogiltig inmatning, försök igen.");
                        AppTools.WaitForEnterKey();
                    }

                } while (!userIsCreated);
            }
        }

        public string[] GetArrayOfUsers()
        {
            List<User> users = _userHandler.GetUsers();
            string[] userArray = new string[users.Count];
            int i = 0;
            foreach (User user in users)
            {
                userArray[i++] = UserFormat.FormatRow(user);
            }

            return userArray;
        }
    }
}
