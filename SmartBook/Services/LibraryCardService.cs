using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Enums.Models;
using SmartBook.Handlers;
using SmartBook.Models;
using SmartBook.Utilities;


namespace SmartBook.Services
{
    public class LibraryCardService
    {
        private LibraryCardHandler _libraryCardHandler = new();


        public LibraryCard FindByCardNumber(Guid cardNumber)
        {
            LibraryCard card = new();
            try
            {
                if (cardNumber == Guid.Empty)
                    throw new ArgumentException("Guid (CardNumber) är tomt.");

                card = _libraryCardHandler.GetByCardNumber(cardNumber);
            }

            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return card;
        }
        public bool CreateLibraryCard(Guid userId)
        {
            bool libraryCardHasBeenCreated = false;
            try
            {
                if (userId == Guid.Empty) 
                    throw new ArgumentException("UserId är null");

                LibraryCard libraryCard = new(userId);
                libraryCard.UpdateStatus(LibraryCardStatus.Active);

                _libraryCardHandler.Add(libraryCard);
                libraryCardHasBeenCreated = true;

            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }
            
            return libraryCardHasBeenCreated;
        }

        public bool EditStatus(Guid id, LibraryCardStatus newStatus)
        {
            bool libraryCardHasBeenEdited = false;
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentException("Guid är tom.");

                _libraryCardHandler.EditStatus(id, newStatus);
                libraryCardHasBeenEdited = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return libraryCardHasBeenEdited;
        }

        public bool Remove(Guid id)
        {
            bool libraryCardHasBeenRemoved = false;
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentNullException("Guid är tom.");

                _libraryCardHandler.Remove(id);
                libraryCardHasBeenRemoved = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return libraryCardHasBeenRemoved;
        }
    }
}
