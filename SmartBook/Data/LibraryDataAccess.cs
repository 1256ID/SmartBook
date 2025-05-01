using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Utilities;
using SmartBook.Services;
using SmartBook.Data;

namespace SmartBook.Data;

public class LibraryDataAccess
{
    private readonly JsonDatabase _db;

    public LibraryDataAccess(JsonDatabase db)
    {
        _db = db;
    }

    public Library Load()
    {
        return _db.Load();
    }

    public void Save(Library library)
    {
        _db.Save(library);
    }
}
