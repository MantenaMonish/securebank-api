using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace api.DataConnection
{
    public class DBConnection : IDBConnection
    {
        private readonly IConfiguration _configuration;
        public DBConnection(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public SqlConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }
    }
}