using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IAccountRepository
    {
        Task<int> CreateAccount(Account account);
        Task<decimal> GetAccountBalance(int AccountId);
        Task DeleteAccount(int AccountId);
        Task<IEnumerable<JointAccountsDTO>> GetAllJointAccounts();
    }
}