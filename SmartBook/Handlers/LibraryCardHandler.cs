using SmartBook.Models;
using SmartBook.Enums.Models;
using SmartBook.Services;
using SmartBook.Utilities;
using SmartBook.Data;

namespace SmartBook.Handlers
{
    public class LibraryCardHandler 
    {
        private LibraryCardService _libraryCardService;

        public LibraryCardHandler(LibraryCardService libraryCardService)
        {
            _libraryCardService = libraryCardService;
        }

        public LibraryCard FindByCardNumber(Guid cardNumber)
        {
            LibraryCard card = new();
            try
            {
                if (cardNumber == Guid.Empty)
                    throw new ArgumentException
                         (
                             "Guid '" + nameof(cardNumber) + "' är tomt.",
                             nameof(cardNumber)
                         );

                card = _libraryCardService.GetByCardNumber(cardNumber);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return card;
        }

        public List<LibraryCard> GetLibraryCards()
        {
            List<LibraryCard> cards = [];

            try
            {
                cards = _libraryCardService.GetLibraryCards();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return cards;
        }
        public bool CreateLibraryCard(Guid userId)
        {
            bool libraryCardHasBeenCreated = false;
            try
            {
                if (userId == Guid.Empty)
                    throw new ArgumentException
                         (
                             "Guid '" + nameof(userId) + "' är tomt.",
                             nameof(userId)
                         );

                LibraryCard libraryCard = new(userId);
                libraryCard.SetStatus(LibraryCardStatus.Active);

                _libraryCardService.Add(libraryCard);
                libraryCardHasBeenCreated = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return libraryCardHasBeenCreated;
        }

        public bool EditStatus(Guid libraryCardId, LibraryCardStatus newStatus)
        {
            bool libraryCardHasBeenEdited = false;
            try
            {
                if (libraryCardId == Guid.Empty)
                    throw new ArgumentException
                        (
                            "Guid '" + nameof(libraryCardId) + "' är tomt.",
                            nameof(libraryCardId)
                        );

                _libraryCardService.EditStatus(libraryCardId, newStatus);
                libraryCardHasBeenEdited = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return libraryCardHasBeenEdited;
        }

        public bool Remove(Guid libraryCardId)
        {
            bool libraryCardHasBeenRemoved = false;
            try
            {
                if (libraryCardId == Guid.Empty)
                    throw new ArgumentException
                        (
                            "Guid '" + nameof(libraryCardId) + "' är tomt.",
                            nameof(libraryCardId)
                        );

                _libraryCardService.Remove(libraryCardId);
                libraryCardHasBeenRemoved = true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return libraryCardHasBeenRemoved;
        }

        public bool LibraryCardExists(Guid libraryCardId)
        {
            bool exists = false;
            try
            {
                if (libraryCardId == Guid.Empty)
                    throw new ArgumentException
                        (
                            "Guid '" + nameof(libraryCardId) + "' är tomt.",
                            nameof(libraryCardId)
                        );

                exists = _libraryCardService.LibraryCardExists(libraryCardId);

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return exists;
        }
    }
}
