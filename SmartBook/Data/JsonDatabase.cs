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

        private readonly string FilePath = 
            Path.GetTempPath() +
                @"\SmartBook\" + 
                "library" + 
                ".json";

        public JsonDatabase()
        {

        }

        public void Initialize() 
        {
            SeedData SeedData = new();
            if (!File.Exists(FilePath))
            {
                string seedData = SeedData.LoadData();
                seedData = JsonSerializer.Serialize(seedData);
                File.WriteAllText(FilePath, seedData);
            }
        }

        public Library Load()
        {
            string jsonFile = File.ReadAllText(FilePath);

            if (String.IsNullOrEmpty(jsonFile))
                throw new ArgumentException("library.json är null eller tom.");
            
            Library library = JsonSerializer.Deserialize<Library>(jsonFile) ?? throw new ArgumentNullException("library.json är null eller korrupt.");

            return library;
        }

        public void Save(Library library)
        {                                                
            string jsonFile = JsonSerializer.Serialize<Library>(library) ?? throw new ArgumentNullException("library är null");
            File.WriteAllText(FilePath, jsonFile);                                      
        }
    
    }
}
