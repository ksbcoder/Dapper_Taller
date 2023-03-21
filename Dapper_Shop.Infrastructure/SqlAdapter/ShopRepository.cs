using Dapper;
using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;
using Dapper_Shop.Infrastructure.Gateway;

namespace Dapper_Shop.Infrastructure.SqlAdapter
{
    public class ShopRepository : IShopRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string _tableName = "shop";
        public ShopRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }
        public async Task<Shop> CreateShop(Shop shop)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var shopToCreate = new
            {
                name = shop.Name_shop,
                phone = shop.Phone_shop,
                address = shop.Address_shop,
                rating = shop.Rating_shop
            };

            Shop.Validate(shopToCreate.name, shopToCreate.address, shopToCreate.phone, shopToCreate.rating);

            var sql = $"INSERT INTO {_tableName} (name_shop, phone_shop, address_shop, rating_shop) VALUES (@name, @phone, @address, @rating);";
            var result = await connection.ExecuteAsync(sql, shopToCreate);
            connection.Close();
            return shop;
        }
        public async Task<List<Shop>> GetShops()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var sql = $"SELECT * FROM {_tableName}";
            var shops = await connection.QueryAsync<Shop>(sql);
            connection.Close();
            return shops.ToList();
        }

        public async Task<Shop> GetShopById(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var sql = $"SELECT * FROM {_tableName} WHERE shop_id = @id";
            var shop = await connection.QuerySingleAsync<Shop>(sql, new { id });
            connection.Close();
            return shop;
        }
    }
}
