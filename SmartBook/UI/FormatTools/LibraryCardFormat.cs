using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Enums;
using SmartBook.Enums.Models;
using SmartBook.Models;

namespace SmartBook.UI.FormatTools;

public static class LibraryCardFormat
{
    public static string GetHeader()
    {      
        string header = string.Format
        (
            "{0,-18}{1,-18}{2,-12}{3,-2}\n",
            "Kort nummer:", 
            "Utfärdsdatum:", 
            "Utgångsdatum:", 
            "Lånekortsstatus:"              
        );

        return header;
    }

    public static string FormatDetailsAsString(LibraryCard card)
    {
        string status = LibraryCardStatusExtensions.GetSwedishName(card.Status);
        string outputArray =

            "\nKort nummer: " +         card.CardNumber.ToString() +
            "\nUtfärdsdatum: " +        card.IssuedDate.ToString("yyyy-MM-dd") +
            "\nUtgångsdatum: " +        card.ExpiryDate.ToString("yyyy-MM-dd") +
            "\nLånekortsstatus: " +     status;
        
        return outputArray;
    }

    public static string[] FormatDetailsAsArray(LibraryCard card)
    {
        string status = LibraryCardStatusExtensions.GetSwedishName(card.Status);
        
        string[] outputArray =
        [
            "Kort nummer: " +       card.CardNumber.ToString(),
            "Utfärdsdatum: " +      card.IssuedDate.ToString("yyyy-MM-dd"),
            "Utgångsdatum: " +      card.ExpiryDate.ToString("yyyy-MM-dd"),
            "Lånekortsstatus: " +   status,
            "Gå tillbaka till förgående meny"
        ];

        return outputArray;
    }

    public static string FormatRow(LibraryCard card)
    {
        string status = LibraryCardStatusExtensions.GetSwedishName(card.Status);     

        string output = string.Format
        (
            "{0,-18}{1,-18}{2,-12}{3,-2}\n",
            card.CardNumber.ToString(), 
            card.IssuedDate.ToString("yyyy-MM-dd"),
            card.ExpiryDate.ToString("yyyy-MM-dd"), 
            status
        );

        return output;
    }
}
