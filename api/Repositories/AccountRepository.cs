using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DataConnection;
using api.Interfaces;
using api.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using api.Dtos;

namespace api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDBConnection _db;
        public AccountRepository(IDBConnection db)
        {
            _db = db;
        }
        public async Task<int> CreateAccount(Account account)
        {
            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_CreateAccount", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@AccountNumber",account.AccountNumber);
            cmd.Parameters.AddWithValue("@AccountTypeId",account.AccountTypeId);
            cmd.Parameters.AddWithValue("@Balance",account.Balance);
            cmd.Parameters.AddWithValue("@IsJoint",account.IsJointAccount);
            cmd.Parameters.AddWithValue("@UserId",account.UserId);

            await conn.OpenAsync();
            return Convert.ToInt32( await cmd.ExecuteScalarAsync());
        }

        public async Task<decimal> GetAccountBalance(int AccountId)
        {
            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_GetAccountBalance", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@AccountId", AccountId );

            await conn.OpenAsync();
            return Convert.ToDecimal(await cmd.ExecuteScalarAsync());
        }

        public async Task DeleteAccount(int AccountId)
        {
            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_DeleteAccount", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@AccountId",AccountId);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<JointAccountsDTO>> GetAllJointAccounts()
        {
            List<JointAccountsDTO> jointAccounts = new List<JointAccountsDTO>();

            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_GetAllJointAccounts", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            await conn.OpenAsync();

            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                jointAccounts.Add(new JointAccountsDTO
                {
                    JointMemberId = Convert.ToInt32(reader["JointMemberId"]),
                    AccountId = Convert.ToInt32(reader["AccountId"]),
                    UserId = Convert.ToInt32(reader["UserId"])
                });
            }

            return jointAccounts;
        }
    }
}