using Dapper_Shop.Infrastructure.Gateway;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper_Shop.Infrastructure.SqlAdapter
{
    public class DbConnectionBuilder : IDbConnectionBuilder
    {
        private readonly string _connectionString;

        public DbConnectionBuilder(string connectionString) =>

            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));


        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }
    }
}
