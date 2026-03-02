using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Auth;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.Identity.Client;

namespace api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        public async Task<string> Register(RegisterDTO registerDTO)
        {
            var existingUser = await _userRepo.GetByEmail(registerDTO.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }
            var user = new User
            {
                UserName = registerDTO.FullName,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                DOB = registerDTO.DOB,
                PermanentAddress = registerDTO.Address,
                MaritalStatus = registerDTO.MaritalStatus,
                PasswordHash = PasswordHasher.Hash(registerDTO.Password),
                Role = "User"                                       
            };

            await _userRepo.CreateUser(user);

            return "User Registered Successfully";
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            var user = await _userRepo.GetByEmail(loginDTO.Email);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            var hash = PasswordHasher.Hash(loginDTO.Password);

            if(user.PasswordHash != hash)
            {
                throw new Exception("Invalid Credentials");
            }

            return _tokenService.CreateToken(user);
        }
    }
}