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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionservice;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionservice = transactionService;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> TransferFunds(TransactionDTO transactionDTO)
        {
            await _transactionservice.TransferFunds(transactionDTO);
            return Ok("The Transaction Has Been Successful");
        }
    }
}