using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Utilities;

public class Menu
{

    public static string continueText = "\n\nKlicka på valfri tangent för att fortsätta";

    /* 

        Metoden 'Display()' innehåller logiken för menyn och har tre parametrar...

         - Ingångs array:n (string[] arr) vilket innehåller alla menyval.

         - 'int index' vilket innehåller index för att veta vilket menyval som 
           användaren senast var på.

         - Samt 'string menuTitle' vilket innehåller rubriken för menyn men är  
           inte nödvändig för att menyn ska fungera.

    */

    public static int Display(string menuTitle, string[] arr, int index)
    {       
        bool indexIsChosen = false;
        int maxAmountOfChars = arr.Max(arr => arr.Length) + 7;
        string menuOutliners = "";

        for (int i = 0; i < maxAmountOfChars; i++)
        {
            menuOutliners += "*";
        }

        while (!indexIsChosen)
        {
            Console.Clear();
            Console.WriteLine(menuTitle + "\n");
            Console.WriteLine(menuOutliners);


            /* 

                Denna for-loop används för att ändra på menyvalet
                som användaren har valt så att de visuellt kan se
                när de har markerat det.

                Vad som loopas igenom är själva input 'string[] arr)

            */

            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] == "Gå tillbaka till förgående meny")
                    Console.WriteLine(menuOutliners + "\n");

                string output = arr[i];

                if (i == index)
                {
                    Console.Write("  ");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write(arr[i]);

                Console.ResetColor();

                if (i == index)
                {
                    Console.Write(" <---");
                }

                Console.Write("\n");
            }

            if (arr[arr.Length - 1] != "Gå tillbaka till förgående meny")
                Console.WriteLine(menuOutliners);

            // Läser in tangent-input från användare

            ConsoleKeyInfo input = Console.ReadKey();

            /*
                Denna switch-statement Justerar index efter vilken piltangent
                som används eller ifall användaren väljer att gå vidare.

                Default case:t används ifall användaren väljer att använda 
                någon annan tangent än pil upp/ner eller ENTER.

            */

            switch (input.Key)
            {

                case ConsoleKey.UpArrow:
                    if (index != 0)
                    {
                        index--;
                    }
                break;

                case ConsoleKey.DownArrow:
                    if (index < arr.Length - 1)
                    {
                        index++;
                    }
                break;

                case ConsoleKey.Enter:
                    if (index < arr.Length)
                    {
                        indexIsChosen = true;
                    }
                break;


                default:
                    Console.Clear();
                    Console.WriteLine
                        (
                            "Felaktiga tangenter har använts, var vänlig och använd " +
                            "piltangenterna UPP/NER och ENTER för att bekräfta ett val." +
                            continueText
                        );
                    Console.ReadKey();
                break;
            }
        }

        /* 
            När användaren har valt ett menyval så returnerar metoden
            en int med index för vilket menyval som har valts.
        */

        return index;
    }
}
