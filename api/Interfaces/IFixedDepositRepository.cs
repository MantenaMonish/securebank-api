using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IFixedDepositRepository
    {
        Task CreateFD(FundTransferDTO fundTransferDTO);
        // IEnumerable<FixedDeposit> GetFDsByAccount(int accountId); need sp
        Task CloseFD(int fdId);
    }
}