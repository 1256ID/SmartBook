using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Enums.Models;

public enum BookCondition
{
    New,
    Good,
    Fair,
    Poor,
    Damaged
}

public static class BookConditionExtensions
{
    public static string GetSwedishName(BookCondition condition)
    {
        return condition switch
        {
            BookCondition.New => "Ny",
            BookCondition.Good => "Bra",
            BookCondition.Fair => "Okej",
            BookCondition.Poor => "Dålig",
            BookCondition.Damaged => "Skadad",
            _ => "Okänt"
        };
    }
}
