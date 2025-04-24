using SmartBook.Utilities;

namespace SmartBook;

public class App
{
    static void Main()
    {
        // Load in Database

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
