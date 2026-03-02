using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositController : ControllerBase
    {
        private readonly IFixedDepositService _fixedDepositService;
        public DepositController(IFixedDepositService fixedDepositService)
        {
            _fixedDepositService = fixedDepositService;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> CreateFixedDeposit(FundTransferDTO fundTransferDTO)
        {

            await _fixedDepositService.CreateFD(fundTransferDTO);
            return Ok("Fixed Deposit Created Successfully");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete] 
        public async Task<IActionResult> CloseFixedDeposit(int FdId)
        {
            await _fixedDepositService.CloseFD(FdId);
            return Ok("Fixed Deposit Closed Successfully");
        }
    }
}