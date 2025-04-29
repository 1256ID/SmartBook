using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Enums.Models;
using SmartBook.Services;

namespace SmartBook.Handlers
{
    public class LibraryCardHandler 
    {
        private LibraryService _libraryService = new();
        private List<LibraryCard> LibraryCards => _libraryService.GetLibraryCards();

        public LibraryCard GetByCardNumber(Guid cardNumber) 
            => LibraryCards.FirstOrDefault(c => c.CardNumber == cardNumber) 
            ?? throw new ArgumentNullException("Objektet 'LibraryCard' returnerade null.");

        public void Add(LibraryCard card)
        {           
            LibraryCards.Add(card);               
        }

        public void EditStatus(Guid id, LibraryCardStatus newStatus)
        {
            try
            {
                var targetLibraryCard = LibraryCards
                    .Where(c => c.Id == id)
                    .FirstOrDefault() ?? 
                    throw new ArgumentNullException("Lånekortet du försökte ändra returnerade null.");

                targetLibraryCard.UpdateStatus(newStatus);
            }

            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex);
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

                var targetLibraryCard = LibraryCards.FirstOrDefault(c => c.Id == id) ?? 
                    throw new ArgumentNullException("Den angivna boken existerar inte i vår databas.");
                               
                LibraryCards.Remove(targetLibraryCard);                             
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }


        }
    }
}
