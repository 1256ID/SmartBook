using SmartBook.Services;
using SmartBook.UI;
using SmartBook.Models;
using SmartBook.Handlers;
using SmartBook.Data;
using SmartBook.Repository;

namespace SmartBook;

public class App
{
    private Library _library;
    private BookHandler _bookHandler;


    
    
    static void Run()
    {
        // Load in Database

        var jsonDb = new JsonDatabase();
        var dataAccess = new LibraryDataAccess(jsonDb); 
        var repository = new LibraryRepository(dataAccess);

        // Book

        var bookService = new BookService(repository);
        var bookHandler = new BookHandler(bookService);

        // LibraryCard

        var libraryCardService = new LibraryCardService(repository);
        var libraryCardHandler = new LibraryCardHandler(libraryCardService);

        // Loan

        var loanService = new LoanService(repository);
        var loanHandler = new LoanHandler(loanService);

        // User

        var userService = new UserService(repository);
        var userHandler = new UserHandler(userService);


        // Starting variables

        MenuManager menuManager = new();
        
        bool runningApp = true;
        int index = 0;

        do
        {
            index = Menu.Display
                (
                    "Ivans Bibliotek",
                    [                                               
                        "Hantera användare",                     
                        "Hantera böcker",
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
                    menuManager.ManageLibraryCards();
                break;

                case 2:
                    menuManager.ManageUsers();
                break;

                case 3:
                    runningApp = false;
                break;

            }

        } while (runningApp);

        Environment.Exit(0);
    }
}
