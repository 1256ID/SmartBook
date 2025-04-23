using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook
{
    internal class MenuManager
    {
        public void ManageBooks() 
        {
            bool managingBooks = true;
            int index = 0;

            do
            {
                index = Menu.Display
                    (
                        "Ivans Bibliotek",
                        [                           
                            "Lägg till en bok",
                            "Ta bort en bok",
                            "Lista alla böcker",
                            "Sök efter bok",
                            "Gå tillbaka till förgående meny"
                        ], index
                    );


                switch (index)
                {

                    case 0:

                        break;

                    case 1:

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
}
