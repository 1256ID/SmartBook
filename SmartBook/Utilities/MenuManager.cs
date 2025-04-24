using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace SmartBook.Utilities;

public class MenuManager
{
    public void ManageBooks() 
    {
        MenuActionHandler menuActionHandler = new();
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
                        "Redigera",                        
                        "Gå tillbaka till förgående meny"
                    ], index
                );

            switch (index)
            {
                case 0:
                    menuActionHandler.AddBook();
                break;
                    
                case 1:
                    menuActionHandler.RemoveBook();
                break;

                case 2:

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
