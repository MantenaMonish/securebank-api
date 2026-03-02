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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // [HttpPost("register")]
        // public IActionResult RegisterUser([FromBody] UserCreateDTO userCreateDTO)
        // {
        //     _userService.RegisterUser(userCreateDTO);
        //     return Ok("'User Registered Successfully");
        // }

        [Authorize(Roles = "User")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await _userService.UpdateUserProfile(user);
            return Ok("'User Profile Updated Successfully");
        }

        [Authorize(Roles = "User")]
        [HttpGet("{userId}/overview")]
        public async Task<IActionResult> GetUserOverview(int userId)
        {
            var result = await _userService.GetUserOverview(userId);
            return Ok(result);
        }
    }
}