using Microsoft.Data.SqlClient;
using System.Data;

namespace TradeCLI.DB
{
    public  class DapperContext
    {
       
        private readonly string _connectionString;
        public DapperContext()
        {
        
            _connectionString = ConnectionString.CreateConnetionString();
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
