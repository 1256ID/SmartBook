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
        
        public void Initilize() 
        {
            SeedData SeedData = new();
            if (!File.Exists(FilePath))
            {
                string seedData = SeedData.LoadData();
                seedData = JsonSerializer.Serialize(seedData);
                File.WriteAllText(FilePath, seedData);
            }
        }    

        internal Library Load()
        {
            Library? library = new();
            try
            {
                string jsonFile = File.ReadAllText(FilePath);

                if (String.IsNullOrEmpty(jsonFile))
                    throw new ArgumentException("library.json är null eller tom.");

                library = JsonSerializer.Deserialize<Library>(jsonFile) ?? throw new ArgumentNullException("library.json är null eller korrupt.");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
                Console.WriteLine("Klicka på valfri tangent för att fortsätta.");
            }

            return library;
        }

        internal void Save(Library library)
        {
            try
            {                              
                string jsonFile = JsonSerializer.Serialize<Library>(library) ?? throw new ArgumentNullException("library är null");
                File.WriteAllText(FilePath, jsonFile);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
                Console.WriteLine("Klicka på valfri tangent för att fortsätta.");
            }
        }
    
    }
}
