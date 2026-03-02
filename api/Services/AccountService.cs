using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using api.Models;

namespace api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task RegisterAccount(AccountCreateDTO accountCreateDTO)
        {
            var acc = new Account
            {
                AccountNumber = accountCreateDTO.AccountNumber,
                AccountTypeId = accountCreateDTO.AccountTypeId,
                Balance = accountCreateDTO.Balance,
                IsJointAccount = accountCreateDTO.IsJointAccount,
                UserId = accountCreateDTO.UserId
            };
            await _accountRepository.CreateAccount(acc);
        }

        public async Task<decimal> GetBalance(int AccountId)
        {
            return await _accountRepository.GetAccountBalance(AccountId);
        }

        public async Task DeleteAccount(int AccountId)
        {
            await _accountRepository.DeleteAccount(AccountId);
        }

        public async Task<IEnumerable<JointAccountsDTO>> GetAllJointAccounts()
        {
            return await _accountRepository.GetAllJointAccounts();
        }
    }
}