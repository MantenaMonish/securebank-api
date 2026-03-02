using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAccount(AccountCreateDTO accountCreateDTO);
        Task<decimal> GetBalance(int AccountId);
        Task DeleteAccount(int AccountId);
        Task<IEnumerable<JointAccountsDTO>> GetAllJointAccounts();
    }
}