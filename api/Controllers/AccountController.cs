using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> RegisterAccount([FromBody] AccountCreateDTO accountCreateDTO)
        {
            await _accountService.RegisterAccount(accountCreateDTO);
            return Ok("Account Registered Successfully");
        }

        [Authorize(Roles = "User")]
        [HttpGet("{AccountId}/balance")]
        public async Task<IActionResult> GetAccountBalance(int AccountId)
        {
            var bal = await _accountService.GetBalance(AccountId);
            return Ok(bal);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int AccountId)
        {
            await _accountService.DeleteAccount(AccountId);
            return Ok("Account Is not Active Anymore");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetJointMembers")]
        public async Task<IActionResult> GetAllJointMembers()
        {
            var result = await _accountService.GetAllJointAccounts();
            return Ok(result);
        }
    }
}