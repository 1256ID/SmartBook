using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Services;
using SmartBook.Session;
using SmartBook.Utilities;

namespace SmartBook.Handlers
{
    public class LoanHandler
    {

        private readonly LoanService _loanService;
        private readonly UserContext _userContext;

        public LoanHandler(LoanService loanService, UserContext userContext)
        {
            _loanService = loanService;
            _userContext = userContext;
        }

        public Loan GetLoan(Guid loanId)
        {
            Loan loan = new();

            try
            {
                if (loanId == Guid.Empty)
                    throw new ArgumentException
                         (
                             "Guid '" + nameof(loanId) + "' är tomt.",
                             nameof(loanId)
                         );

                loan = _loanService.GetLoan(loanId);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return loan;
        }

        public List<Loan> GetLoans()
        {
            List<Loan> loans = [];
            try
            {
                loans = _loanService.GetLoans();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                AppTools.WaitForEnterKey();
            }

            return loans;
        }

        public bool CreateLoan(Book book, Guid userId, Guid cardNumber)
        {
            bool loanIsCreated = false;      

            try
            {
                ArgumentNullException.ThrowIfNull(book, nameof(book) + " returnerade null.");
                if (userId == Guid.Empty)
                    throw new ArgumentException("Guid '" + nameof(userId) + "' är tomt.", nameof(userId));
                if (cardNumber == Guid.Empty)
                    throw new ArgumentException("Guid '" + nameof(cardNumber) + "' är tomt.", nameof(cardNumber));

                User? user = _userContext.SelectedUser;
                
                if (user != null)
                {
                    
                    Loan loan = new(book.BookInfo.ISBN, cardNumber, book.Id, user.Id);
                    loanIsCreated = _loanService.Add(loan);
                }
                
            }

            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
                AppTools.WaitForEnterKey();
            }

            return loanIsCreated;
        }

        

    }
}
