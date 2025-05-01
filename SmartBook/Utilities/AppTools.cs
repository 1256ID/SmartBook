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

        public static string PromptUserForTextInput(string variableName)
        {
            string output = "";
            bool waitingForCorrectInput = true;

            while (waitingForCorrectInput)
            {
                try
                {
                    Console.Clear();
                    Console.Write(variableName);
                    string ? input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Inmatningen får inte vara tom.\n\n");
                        AppTools.WaitForEnterKey();
                    }

                    else
                    {
                        if (input != null)
                        {
                            output = input;
                        }

                        waitingForCorrectInput = false;
                    }
                }

                catch
                {
                    Console.WriteLine("Ogiltig inmatning\n\n");
                    AppTools.WaitForEnterKey();
                }
            }

            return output;

        }
    }
}
