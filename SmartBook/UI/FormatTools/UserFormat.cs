using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Enums.Models;
using SmartBook.Models;
using SmartBook.Services;

namespace SmartBook.UI.FormatTools;

public static class UserFormat
{      
    public static string GetHeader()
    {
        // Namn, Email, Har användare lånekort?

        string header = string.Format
        (
            "{0,-18}{1,-18}{2,-12}\n",
            "Namn:",
            "Email:",
            "Lånekort:"         
        );

        return header;
    }

    public static string FormatDetailsAsString(User user)
    {
        bool userHasLibraryCard = user.LibraryCard != null;
        string outputArray =

            "\nNamn: " +        user.Name +
            "\nEmail: " +       user.Email +
            "\nLånekort: " +    userHasLibraryCard;
            
        return outputArray;
    }

    public static string[] FormatDetailsAsArray(User user)
    {
        string[] outputArray =
        [
            "Namn: " +      user.Name,
            "Email: " +     user.Email
        ];

        return outputArray;
    }

    public static string FormatRow(User user)
    {
        bool userHasLibraryCard = user.LibraryCard != null;
        string output = string.Format
        (
            "{0,-18}{1,-18}{2,-12}\n",
            user.Name,
            user.Email,
            userHasLibraryCard            
        );

        return output;
    }
}
