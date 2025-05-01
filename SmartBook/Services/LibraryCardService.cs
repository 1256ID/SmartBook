using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Enums.Models;
using SmartBook.Handlers;
using SmartBook.Models;
using SmartBook.Repository;
using SmartBook.Utilities;


namespace SmartBook.Services
{
    public class LibraryCardService
    {
        private LibraryRepository _repository;
        public LibraryCardService(LibraryRepository repository)
        {
            _repository = repository;
        }

        private List<LibraryCard> LibraryCards => _repository.GetLibraryCards();

        public LibraryCard GetByCardNumber(Guid cardNumber)
            => LibraryCards.FirstOrDefault(c => c.CardNumber == cardNumber)
            ?? throw new InvalidOperationException("Inget lånekort med angivet " + nameof(cardNumber) + " hittades.");

        public List<LibraryCard> GetLibraryCards() => _repository.GetLibraryCards();

        public void Add(LibraryCard card)
        {
            LibraryCards.Add(card);
        }

        public void EditStatus(Guid id, LibraryCardStatus newStatus)
        {
            var targetLibraryCard
                = LibraryCards
                    .Where(c => c.Id == id)
                    .FirstOrDefault()

                ?? throw new ArgumentNullException
                    (
                        nameof(id),
                        "Objektet 'LibraryCard' innehållandes '" + nameof(id) + "' returnerade null."
                    );

            targetLibraryCard.SetStatus(newStatus);
        }

        public void Remove(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id), "Guid '" + nameof(id) + "' är tomt.");

            var targetLibraryCard = LibraryCards.FirstOrDefault(c => c.Id == id) ??
                throw new ArgumentNullException
                (
                    nameof(id),
                    "Objektet 'LibraryCard' innehållandes '" + nameof(id) + "' returnerade null."
                );

            LibraryCards.Remove(targetLibraryCard);
        }

        public bool LibraryCardExists(Guid libraryCardId)
        {
            return LibraryCards.Exists(c => c.Id.Equals(libraryCardId));
        }

    }
}
