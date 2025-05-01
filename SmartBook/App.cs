using SmartBook.Services;
using SmartBook.UI;
using SmartBook.Models;
using SmartBook.Handlers;
using SmartBook.Data;
using SmartBook.Repository;
using SmartBook.Session;
using SmartBook.UI.MenuHandlers;
using SmartBook.Utilities;

namespace SmartBook;

public class App
{
    static void Main()
    {

        // Ladda in JsonDB

        var jsonDb = new JsonDatabase();
        var dataAccess = new LibraryDataAccess(jsonDb);
        var repository = new LibraryRepository(dataAccess);

        var userContext = new UserContext();

        // Services

        var bookService = new BookService(repository);
        var libraryCardService = new LibraryCardService(repository);
        var loanService = new LoanService(repository);
        var userService = new UserService(repository);

        // Handlers

        var bookHandler = new BookHandler(bookService, userContext);
        var libraryCardHandler = new LibraryCardHandler(libraryCardService, userContext);
        var loanHandler = new LoanHandler(loanService, userContext);
        var userHandler = new UserHandler(userService, userContext);

        // Menu

        var menuManager = new MenuManager(bookHandler, libraryCardHandler, loanHandler, userHandler, userContext);
        var userManager = new UserMenuHandler(bookHandler, libraryCardHandler, loanHandler, userHandler, userContext);

        // Välj eller skapa användare.     

        userManager.SelectOrCreateUser();

        // Starting variablar

        bool runningApp = true;
        int index = 0;

        do
        {
            index = Menu.Display
                (
                    "Ivans Bibliotek",
                    [                       
                        "Hantera böcker",
                        "Hantera användare",
                        "Hantera lånekort",
                        "Avsluta programmet"

                    ], index
                );

            switch (index)
            {

                case 0:
                    menuManager.ManageBooks();                  
                    break;

                case 1:
                    menuManager.ManageUsers();                                   
                    break;

                case 2:
                    menuManager.ManageLibraryCards();
                    break;

                case 3:
                    runningApp = false;
                    break;

            }

        } while (runningApp);

        Environment.Exit(0);
    }
}
