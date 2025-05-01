using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Data.Enums;
using SmartBook.Utilities;
using SmartBook.Models;
using System.Text.Json;
using System.IO.Enumeration;

namespace SmartBook.Data
{
    public class JsonDatabase
    {
        // Vad jag behöver: En lista för varje typ som sedan ska konverteras till/från JSON.

        private readonly string _filePath = 
            Path.Combine
            (
                Path.GetTempPath(),
                "SmartBook",
                "library.json"
            );

        public JsonDatabase()
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "SmartBook");

            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }

            _filePath = Path.Combine(tempPath, "library.json");
        }    

        public Library Load()
        {

            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("Fil saknas. Initierar ny databas med testdata...");
                    var seedData = SeedData.GetLibrary();                                  
                    Save(seedData);
                    return seedData;
                }

                string jsonFile = File.ReadAllText(_filePath);

                if (string.IsNullOrWhiteSpace(jsonFile))
                    throw new InvalidDataException("Innehållet i library.json är tomt.");

                var library = JsonSerializer.Deserialize<Library>(jsonFile);

                return library ?? throw new JsonException("Kunde inte deserialisera library.json – formatet kan vara fel.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Fel vid inläsning av biblioteket.", ex);
            }
        }

        public void Save(Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library), "Library är null.");

            string jsonFile = JsonSerializer.Serialize(library, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, jsonFile);
        }

    }
}
