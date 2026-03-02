using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using api.DataConnection;
using api.Interfaces;
using api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using api.Dtos;


namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDBConnection _db;
        public UserRepository(IDBConnection db)
        {
            _db = db;
        }
        public async Task CreateUser(User user)
        {
            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_CreateUser", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserName", user.UserName );
            cmd.Parameters.AddWithValue("@DOB", user.DOB );
            cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber );
            cmd.Parameters.AddWithValue("@Email", user.Email );
            cmd.Parameters.AddWithValue("@Address", user.PermanentAddress );
            cmd.Parameters.AddWithValue("@MaritalStatus", user.MaritalStatus );
            cmd.Parameters.AddWithValue("@PasswordHash",user.PasswordHash);
            cmd.Parameters.AddWithValue("@Roles", user.Role);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_GetUserByEmail", conn)
            {
                CommandType =CommandType.StoredProcedure  
            };

            cmd.Parameters.AddWithValue("@Email", email);
            await conn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();

            if(!await reader.ReadAsync()) return null;

            return new User
            {
                UserId = (int)reader["UserId"],
                Email = reader["Email"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                Role = reader["Roles"].ToString()
            };
        }

        public async Task<IEnumerable<AccountSummaryDTO>> GetUserOverview(int userId)
        {
            var accounts = new List<AccountSummaryDTO>();
            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_GetUserOverview", conn)
            {
               CommandType = CommandType.StoredProcedure  
            };

            cmd.Parameters.AddWithValue("@UserId", userId);
            await conn.OpenAsync();

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                accounts.Add(new AccountSummaryDTO
            {
                AccountId = Convert.ToInt32(reader["AccountId"]),
                AccountNumber = reader["AccountNumber"].ToString(),
                AccountTypeName = reader["AccountTypeName"].ToString(),
                Balance = Convert.ToDecimal(reader["Balance"]),
                IsJointAccount = Convert.ToBoolean(reader["IsJointAccount"])
            });
            
            }
            return accounts;
        }

        public async Task UpdateUser(User user)
        {
            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_UpdateUserDetails", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@UserName", user.UserName );
            cmd.Parameters.AddWithValue("@Address", user.PermanentAddress );
            cmd.Parameters.AddWithValue("@MaritalStatus", user.MaritalStatus );
            cmd.Parameters.AddWithValue("@Phone", user.PhoneNumber );
            cmd.Parameters.AddWithValue("@UserId", user.UserId );

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}