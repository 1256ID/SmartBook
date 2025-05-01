using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBook.Models;
using SmartBook.Handlers;
using SmartBook.Utilities;
using SmartBook.Repository;

namespace SmartBook.Services
{
    public class LoanService
    {
        private LibraryRepository _repository;
        public LoanService(LibraryRepository repository)
        {
            _repository = repository;
        }

        public Loan GetLoan(Guid loanId)
            => GetLoans().FirstOrDefault(c => c.Id == loanId)
            ?? throw new InvalidOperationException("Inget boklån med angivet " + nameof(loanId) + " hittades.");
        public List<Loan> GetLoans() => _repository.GetLoans();

        
        public bool Add(Loan loan)
        {
            _repository.Add(loan);
            return true;
        }
    }
}
