using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Handlers;
using SmartBook.UI.MenuHandlers;


namespace SmartBook.UI;

public class MenuManager
{

    private readonly BookHandler _bookHandler;
    private readonly LibraryCardHandler _libraryCardHandler;
    private readonly LoanHandler _loanHandler;
    private readonly UserHandler _userHandler;
    
    public MenuManager(BookHandler bookHandler, LibraryCardHandler libraryCardHandler, LoanHandler loanHandler, UserHandler userHandler)
    {
        _bookHandler = bookHandler;
        _libraryCardHandler = libraryCardHandler;
        _loanHandler = loanHandler;
        _userHandler = userHandler;
    }
    public void ManageBooks() 
    {
        BookMenuHandler bookMenuHandler = new(_bookHandler, _libraryCardHandler, _loanHandler, _userHandler);
        bool managingBooks = true;
        int index = 0;

        do
        {           
            index = Menu.Display
                (
                    "Böcker",
                    [
                        "Sök",
                        "Lägg till",
                        "Visa boklista",                        
                        "Gå tillbaka till förgående meny"
                    ], index
                );

            switch (index)
            {
                case 0:
                    bookMenuHandler.SearchForBook();
                break;
                    
                case 1:
                    bookMenuHandler.AddBook();
                break;

                case 2:
                    bookMenuHandler.ListBooks();
                    break;

                case 3:
                    managingBooks = false;
                break;

            }

        } while (managingBooks);
    }

    public void ManageLibraryCards()
    {

    }

    public void ManageUsers()
    {

    }

}
