using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.UseCases.Gateway;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;

namespace Dapper_Shop.Domain.UseCases.UseCases
{
    public class ShopUseCase : IShopUseCase
    {
        private readonly IShopRepository _shopRepository;

        public ShopUseCase(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        public async Task<Shop> CreateShop(Shop shop)
        {
            return await _shopRepository.CreateShop(shop);
        }
        public async Task<List<Shop>> GetShops()
        {
            return await _shopRepository.GetShops();
        }
    }
}
