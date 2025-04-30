using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
