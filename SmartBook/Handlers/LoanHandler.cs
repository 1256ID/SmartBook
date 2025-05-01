using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Services;
using SmartBook.Utilities;

namespace SmartBook.Handlers
{
    public class LoanHandler
    {

        private LoanService _loanService;

        public LoanHandler(LoanService loanService)
        {
            _loanService = loanService;
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

        public bool CreateLoan(Book book, Guid userId)
        {
            bool loanIsCreated = false;      

            try
            {
                ArgumentNullException.ThrowIfNull(book, nameof(book) + " returnerade null.");
                if (userId == Guid.Empty)
                    throw new ArgumentException("Guid '" + nameof(userId) + "' är tomt.", nameof(userId));

                
                Loan loan = new(book.BookInfo.ISBN,);
                loanIsCreated = _loanService.Add(loan); 
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
