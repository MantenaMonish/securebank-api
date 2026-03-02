using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }
        public async Task TransferFunds(TransactionDTO transactionDTO)
        {
            var transac = new Transaction
            {
                FromAccountId = transactionDTO.FromAccountId,
                ToAccountId = transactionDTO.ToAccountId,
                Balance = transactionDTO.Amount
            };

            if(transactionDTO.Amount <= 0)
            {
                throw new ArgumentException ("Transfer Amount Needs To be Greater than ");
            }
            var Bal = Convert.ToDecimal( await _accountRepository.GetAccountBalance(transactionDTO.FromAccountId));
            if (transactionDTO.Amount > Bal)
            {
                throw new InvalidOperationException (" Insufficent Balance ");
            }
            else
            {
                await _transactionRepository.TransferFunds(transac);
            }
        }
    }
}