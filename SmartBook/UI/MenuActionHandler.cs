using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Services;
using SmartBook.Models;
using SmartBook.Utilities;

namespace SmartBook.UI;

public class MenuActionHandler
{

    private BookService _bookService = new();

    public Book SearchForBook()
    {
        int index = 0;
        bool whileSearching = true;
        Book book = new();
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

            // Hittar ingen bok som heter 'Avbryt' så har valt att ha med funktionalitet där användaren kan avbryta sökandet när de vill genom att skriva in 'avbryt' i inmatningen.

            while (input != "avbryt")
            {      
                try
                {
                    Console.Clear();
                    Console.WriteLine("Skriv in 'avbryt' ifall du vill avbryta.");
                    Console.Write("Ange " + menuChoices[index] + ": ");
                    input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.Clear();
                        Console.WriteLine("Inmatningen får inte vara tom eller null.");
                        AppTools.WaitForEnterKey();
                        continue;
                    }

                    else 
                    {
                        if (index == 0)
                        {
                            book = _bookService.GetBookByTitle(input);
                            input = "avbryt";
                        }

                        else if (index == 1)
                        {
                            book = _bookService.GetBookByAuthor(input);
                            input = "avbryt";
                        }

                        else if (index == 2) 
                        {
                            Guid guid = Guid.Empty;

                            bool validGuid = Guid.TryParse(input, out guid);

                            if (validGuid)
                            {
                                book = _bookService.GetBookByISBN(guid);
                            }

                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ogiltigt format/tecken för ISBN, var vänlig och försök igen.");
                                AppTools.WaitForEnterKey();
                            }
                                
                        }

                    }

                    


                }

                catch
                {
                    Console.WriteLine("Ogiltig inmatning kändes igen. Försök igen.");
                    AppTools.WaitForEnterKey();
                }
            }


        } while (whileSearching);

        return(book);
    }

    

    public void AddBook()
    {

    }

    public void ViewBook(Book book)
    {
        int index = 0;
        bool view = true;
        string bookView = FormatTools.BookFormat.FormatDetailsAsString(book) + "\n";
        string[] bookMenu =
        [
               
        ];
        
        do
        {
            Console.Clear();

            index = Menu.Display
                (
                    bookView,
                    [

                        "Redigera",
                        "Ta bort"
                    ], index
                );
            
        } while (view);
    }

    public void EditBook(Book book)
    {
        int index = 0;        
        bool editing = true;
        do
        {

        } while (editing);
    }

    public void RemoveBook() 
    { 
    
    }
}
