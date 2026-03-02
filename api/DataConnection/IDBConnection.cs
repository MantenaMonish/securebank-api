using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace api.DataConnection
{
    public interface IDBConnection 
    {
        SqlConnection CreateConnection();
    }
}