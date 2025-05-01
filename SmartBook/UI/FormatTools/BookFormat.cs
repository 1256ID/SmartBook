using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Enums;
using SmartBook.Enums.Models;

namespace SmartBook.UI.FormatTools;

public static class BookFormat
{
    public static string GetHeader()
    {
        string header = string.Format
        (
            "{0,-18}{1,-18}{2,-12}{3,-2}{4, 12}\n",
            "ISBN:", 
            "Titel:", 
            "Författare:", 
            "Genre:", 
            "Tillgänglighet:"    
        );

        return header;
    }

    public static string FormatDetailsAsString(Book book)
    {
        string status = BookStatusExtensions.GetSwedishName(book.Status);
        string condition = BookConditionExtensions.GetSwedishName(book.Condition);
        string outputArray =

            "\nISBN: " +            book.BookInfo.ISBN.ToString() +
            "\nTitel: " +           book.BookInfo.Title +
            "\nFörfattare: " +      book.BookInfo.Author +
            "\nGenre: " +           book.BookInfo.Genre +
            "\nSkick: " +           condition +
            "\nTillgänglighet: " +  status +
            "\nTillagt datum: " +   book.AddedDate.ToString();


        return outputArray;
    }

    public static string[] FormatDetailsAsArray(Book book)
    {
        string status = BookStatusExtensions.GetSwedishName(book.Status);
        string condition = BookConditionExtensions.GetSwedishName(book.Condition);
        string[] outputArray =
        [
            "ISBN: " +              book.BookInfo.ISBN.ToString(),
            "Titel: " +             book.BookInfo.Title,
            "Författare: " +        book.BookInfo.Author,
            "Genre: " +             book.BookInfo.Genre,
            "Skick: " +             condition,
            "Tillgänglighet: " +    status,
            "Tillagt datum: " +     book.AddedDate.ToString(),

            "\nGå tillbaka till förgående meny"
        ];

        return outputArray;
    }

    public static string FormatRow(Book book)
    {
        var bookInfo = book.BookInfo;
        string status = BookStatusExtensions.GetSwedishName(book.Status);

        string output = string.Format
        (
            "{0,-18}{1,-18}{2,-12}{3,-2}{4, -12}\n",
            bookInfo.ISBN, 
            bookInfo.Title, 
            bookInfo.Author, 
            bookInfo.Genre, 
            status
        );

        return output;
    }

}
