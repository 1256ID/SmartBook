using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Enums.Models;

public enum LibraryCardStatus
{
    Active,
    Blocked,
    Lost,
    Expired
}

public static class LibraryCardStatusExtensions
{
    public static string GetSwedishName(LibraryCardStatus status)
    {
        return status switch
        {
            LibraryCardStatus.Active => "Aktiv",
            LibraryCardStatus.Blocked => "Spärrat",
            LibraryCardStatus.Lost => "Borttappad",
            LibraryCardStatus.Expired => "Utgången",
            _ => "Okänt"
        };
    }
}
