using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Interfaces;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<AccountSummaryDTO>> GetUserOverview(int userId)
        {
            return await _userRepository.GetUserOverview(userId);
        }

        // public void RegisterUser(UserCreateDTO userCreateDTO)
        // {
        //     var user = new User
        //     {
        //         UserName = userCreateDTO.UserName,
        //         DOB = userCreateDTO.DOB,
        //         PhoneNumber = userCreateDTO.PhoneNumber,
        //         Email = userCreateDTO.UserName,
        //         PermanentAddress = userCreateDTO.Address,
        //         MaritalStatus = userCreateDTO.MaritaStatus,
        //         PasswordHash = userCreateDTO.PasswordHash
        //     };
        //     _userRepository.CreateUser(user);
        // }

        public async Task UpdateUserProfile(User user)
        {
            await _userRepository.UpdateUser(user);
        }
    }
}