using Dapper_Shop.Domain.Entities;

namespace Dapper_Shop.Domain.UseCases.Gateway.Repositories
{
    public interface IShopRepository
    {
        Task<List<Shop>> GetShops();
        Task<Shop> CreateShop(Shop shop);
    }
}
