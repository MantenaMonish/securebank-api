using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using api.DataConnection;
using api.Interfaces;
using api.Models;
using Microsoft.Data.SqlClient;

namespace api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDBConnection _db;
        public TransactionRepository(IDBConnection db)
        {
            _db = db;
        }
        public async Task TransferFunds(Transaction transaction)
        {
            using var conn = _db.CreateConnection();
            using var cmd = new SqlCommand("sp_TransferFunds", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@FromAccountId",transaction.FromAccountId);
            cmd.Parameters.AddWithValue("@ToAccountId",transaction.ToAccountId);
            cmd.Parameters.AddWithValue("@Amount",transaction.Balance);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}