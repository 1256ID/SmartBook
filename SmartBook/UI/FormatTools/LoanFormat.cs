using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Enums.Models;
using SmartBook.Models;
using SmartBook.Services;

namespace SmartBook.UI.FormatTools;

public class LoanFormat
{
    private readonly UserService _userService = new();
    private readonly BookService _bookService = new();
    private readonly LibraryCardService _libraryCardService = new();

    public static string GetHeader()
    {
        // ISBN, Titel, Hyrd av (namn), Lånekortsnummer:, Utlånatdatum:, Inlämningsdatum: Returdatum:,

        string header = string.Format
        (
            "{0,-18}{1,-18}{2,-12}{3,-2}\n",
            "ISBN:",
            "Titel:",
            "Hyrd av:",
            "Utlånatdatum:"
        );

        return header;
    }

    public string FormatDetailsAsString(Loan loan)
    {
        var user = _userService.GetUser(loan.UserId);
        var book = _bookService.GetBookByISBN(loan.ISBN);
        var card = _libraryCardService.FindByCardNumber(loan.CardNumber);

        string returnDate = 
            loan.ReturnDate.HasValue ?
            loan.ReturnDate.Value.ToString("yyyy-MM-dd")
            :   "Ej återlämnad";

        string outputArray =

            "\nISBN: " +                loan.ISBN.ToString() +
            "\nTitel: " +               book.BookInfo.Title +
            "\nHyrd av: " +             user.Name +
            "\nLånekortsnummer: " +     card.CardNumber.ToString() +
            "\nUtlånatdatum: " +        loan.LoanDate.ToString("yyyy-MM-dd") +
            "\nInlämningsdatum: " +     loan.DueDate.ToString("yyyy-MM-dd") +
            "\nReturdatum: " +          returnDate;

        return outputArray;
    }

    public string[] FormatDetailsAsArray(LibraryCard card)
    {
        string status = LibraryCardStatusExtensions.GetSwedishName(card.Status);

        string[] outputArray =
        [
            "Kort nummer: " +           card.CardNumber.ToString(),
            "Utfärdsdatum: " +          card.IssuedDate.ToString("yyyy-MM-dd"),
            "Utgångsdatum: " +          card.ExpiryDate.ToString("yyyy-MM-dd"),
            "Lånekortsstatus: " +       status
        ];

        return outputArray;
    }

    public string FormatRow(Loan loan)
    {
        var user = _userService.GetUser(loan.UserId);
        var book = _bookService.GetBookByISBN(loan.ISBN);

        string output = string.Format
        (
            "{0,-18}{1,-18}{2,-12}{3,-2}\n",
            loan.ISBN.ToString(),
            book.BookInfo.Title,
            user.Name,
            loan.LoanDate.ToString("yyyy-MM-dd")
        );

        return output;
    }
}
