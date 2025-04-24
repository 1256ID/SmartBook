using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Models;

public class Book
{
    private Guid _id;
    private Guid _bookInfoId;
    private string _status;
    private string _addedDate;


    public Guid Id
    {
        get => _id;
    }

    public Guid BookInfoId
    {
        get => _bookInfoId;
    }

    public string Status
    {
        get => _status;
        private set => _status = value;
    }

    public string AddedDate
    {
        get => _addedDate;
        private set => _addedDate = value;
    }

    public BookInfo? BookInfo { get; set; }
}
