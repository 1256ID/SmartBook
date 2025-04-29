using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Enums;
using SmartBook.Enums.Models;

namespace SmartBook.Utilities
{
    public static class AppTools
    {         
        public static void WaitForEnterKey()
        {
            while (true)
            {
                Console.WriteLine("\nVar vänlig och klicka ENTER för att fortsätta");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                    break;

                else
                    Console.Clear();
                Console.WriteLine("Ogiltig inmatning, var vänlig och klicka ENTER för att fortsätta");

            }
        }
    }
}
