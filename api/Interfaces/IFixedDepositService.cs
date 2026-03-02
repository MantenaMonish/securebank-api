using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;

namespace api.Interfaces
{
    public interface IFixedDepositService
    {
        Task CreateFD(FundTransferDTO fundTransferDTO);
        Task CloseFD(int FdId);
    }
}