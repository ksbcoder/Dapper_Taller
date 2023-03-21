using Dapper_Shop.Domain.Entities;

namespace Dapper_Shop.Domain.UseCases.Gateway
{
    public interface IShopUseCase
    {
        Task<List<Shop>> GetShops();
        Task<Shop> CreateShop(Shop shop);
    }
}
