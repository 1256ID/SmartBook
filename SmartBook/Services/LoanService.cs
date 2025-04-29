using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Handler;

namespace SmartBook.Services
{
    public class LoanService
    {
        private LoanHandler loanHandler = new();
        public Loan GetLoan(Guid id)
        {
            Loan loan = new();

            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentException("LoanId är null");


                loan = loanHandler.GetLoan(id);
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
