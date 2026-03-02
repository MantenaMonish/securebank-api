using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;

namespace api.Services
{
    public class FixedDepositService : IFixedDepositService
    {
        private readonly IFixedDepositRepository _fixedDeposit;
        public FixedDepositService(IFixedDepositRepository fixedDeposit)
        {
            _fixedDeposit = fixedDeposit;
        }

        public async Task CreateFD(FundTransferDTO fundTransferDTO)
        {
            await _fixedDeposit.CreateFD(fundTransferDTO);
        }

        public async Task CloseFD(int fdId)
        {
            await _fixedDeposit.CloseFD(fdId);
        }
    }
}