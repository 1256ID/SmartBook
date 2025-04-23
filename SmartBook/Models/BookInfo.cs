using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;

internal class BookInfo
{
    private Guid _id;
    private Guid _isbn;
    private string _title;
    private string _author;
    private string _genre;

    public string Title
    {
        get => _title;
        private set => _title = value;
    }

    public string Author
    {
        get => _author;
        private set => _author = value;
    }

    public string Genre
    {
        get => _genre;
        private set => _genre = value;
    }
}

