using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Services;
using SmartBook.Models;

namespace SmartBook.Utilities;

public class MenuActionHandler
{

    private BookService _bookService = new();

    public void SearchForBook()
    {
        int index = 0;
        bool whileSearching = true;
        Book book;
        do
        {
            Console.Clear();
            string? input = "";
            string[] menuChoices = 
            [
                "Titel", 
                "Författare", 
                "ISBN", 
                "Gå tillbaka till förgående meny"
            ];

            index = Menu.Display("Sök efter...", menuChoices, index);

            if ( index == 3 ) 
            {
                whileSearching = false;
            }

            while (input != "avbryt")
            {      
                try
                {
                    Console.Clear();
                    Console.Write("Ange " + menuChoices[index] + ": ");
                    input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Inmatningen får inte vara tom eller null.");
                        AppTools.WaitForEnterKey();

                        continue;
                    }

                    else 
                    {
                        if (index == 0)
                        {
                            book = _bookService.FindByTitle(input);
                        }

                        else if (index == 1)
                        {
                            book = _bookService.FindByAuthor(input);
                        }

                        else if (index == 2) 
                        {
                            Guid guid = Guid.Empty;

                            bool validGuid = Guid.TryParse(input, out guid);

                            if (validGuid)
                            {
                                book = _bookService.FindByISBN(guid);
                            }

                            else
                            {
                                Console.WriteLine("Ogiltigt format/tecken för ISBN, var vänlig och försök igen.");
                                AppTools.WaitForEnterKey();
                            }
                                
                        }

                    }

                    


                }

                catch
                {

                }
            }

            


            

        } while (whileSearching);

        
    }

    

    public void AddBook()
    {

    }

    public void ShowBook(Book book)
    {       
         

    }

    public void EditBook()
    {

    }

    public void RemoveBook() 
    { 
    
    }
}
