using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SmartBook.Enums.Models;
using SmartBook.Models;

namespace SmartBook.Data;

public static class SeedData
{
    public static Library GetLibrary()
    {       
        string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
        string filePath = Path.Combine(root, "Data", "seeddata.json");

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Seeddata-filen saknas: {filePath}");

        string json = File.ReadAllText(filePath);

        var library = JsonSerializer.Deserialize<Library>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return library ?? throw new InvalidDataException("Kunde inte deserialisera seeddata.json");
    }
}

