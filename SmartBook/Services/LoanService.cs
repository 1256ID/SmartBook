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

        private List<Loan> loans => _repository.GetLoans();
        public Loan GetLoan(Guid loanId)
            => loans.FirstOrDefault(c => c.Id == loanId)
            ?? throw new InvalidOperationException("Inget boklån med angivet " + nameof(loanId) + " hittades.");
    }
}
