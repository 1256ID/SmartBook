using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Services;

namespace SmartBook.Handlers
{
    public class LoanHandler
    {
        private LibraryService _libraryService = new();
        private List<Loan> loans => _libraryService.GetLoans();


        public Loan GetLoan(Guid loanId)
        {
            Loan loan = new();
            try
            {                              
                loan = loans.FirstOrDefault(c => c.Id == loanId) ?? throw new ArgumentNullException("Det angivna lånet returnerade null.");
            }

            catch (Exception ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadKey();
                Console.WriteLine("\nKlicka på valfri tangent för att fortsätta.");
            }

            return loan;


        }
    }
}
