
using System.Data;

namespace Dapper_Shop.Infrastructure.Gateway
{
    public interface IDbConnectionBuilder
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
