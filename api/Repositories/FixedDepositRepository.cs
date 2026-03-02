using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DataConnection;
using api.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using api.Dtos;

namespace api.Repositories
{
    public class FixedDepositRepository : IFixedDepositRepository
    {
        private readonly IDBConnection _db;
        public  FixedDepositRepository(IDBConnection db)
        {
            _db = db;
        }
        public async Task CloseFD(int fdId)
        {
            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_CloseFD",conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@fdId",fdId);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task CreateFD(FundTransferDTO fundTransferDTO)
        {
            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_CreateFD",conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@AccountId",fundTransferDTO.AccountId);
            cmd.Parameters.AddWithValue("@Amount",fundTransferDTO.Amount);
            cmd.Parameters.AddWithValue("@Month",fundTransferDTO.Months);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}