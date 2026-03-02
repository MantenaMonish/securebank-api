using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task<IEnumerable<AccountSummaryDTO>> GetUserOverview (int userId);
        Task<User> GetByEmail(string email);
    }
}