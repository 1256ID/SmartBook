using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Enums.Models;
using SmartBook.Handler;
using SmartBook.Models;


namespace SmartBook.Services
{
    public class LibraryCardService
    {
        private LibraryCardHandler _libraryCardHandler = new();

        public void CreateLibraryCard(Guid userId)
        {

            try
            {
                if (userId == Guid.Empty) 
                    throw new ArgumentException("UserId är null");

                LibraryCard libraryCard = new(userId);
                libraryCard.UpdateStatus(LibraryCardStatus.Active);
                _libraryCardHandler.Add(libraryCard);

            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }
            
            
        }

        public void EditStatus(Guid id, LibraryCardStatus newStatus)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentException("Guid är tom.");

                _libraryCardHandler.EditStatus(id, newStatus);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }

        }

        public void Remove(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentNullException("Guid är tom.");

                _libraryCardHandler.Remove(id);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }


        }
    }
}
