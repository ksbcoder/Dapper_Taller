using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;
using Moq;

namespace Tests
{
    public class ShopRepositoryTest
    {
        private readonly Mock<IShopRepository> _mockshopRepository;
        public ShopRepositoryTest()
        {
            _mockshopRepository = new();
        }
        #region tests
        [Fact]
        public async Task CreateShop()
        {
            //arrange
            var shopToCreate = new Shop
            {
                Name_shop = "Victorys",
                Address_shop = "Calle 1",
                Phone_shop = "5558899",
                Rating_shop = 1
            };

            var shopCreated = new Shop
            {
                Name_shop = "Victorys",
                Address_shop = "Calle 1",
                Phone_shop = "5558899",
                Rating_shop = 1
            };

            _mockshopRepository.Setup(x => x.CreateShop(shopToCreate)).ReturnsAsync(shopCreated);

            //act
            var result = await _mockshopRepository.Object.CreateShop(shopToCreate);

            //assert
            Assert.Equal(shopCreated, result);
        }
        [Fact]
        public async Task GetShops()
        {
            //arrange
            List<Shop> shops = new();
            var shop1 = new Shop
            {
                Name_shop = "Victorys",
                Address_shop = "Calle 1",
                Phone_shop = "5558899",
                Rating_shop = 1
            };

            var shop2 = new Shop
            {
                Name_shop = "Akt Shop",
                Address_shop = "Carrera 5",
                Phone_shop = "2223344",
                Rating_shop = 2
            };
            shops.Add(shop1);
            shops.Add(shop2);

            //act
            _mockshopRepository.Setup(x => x.GetShops()).ReturnsAsync(shops);

            //act
            var result = await _mockshopRepository.Object.GetShops();

            //assert
            Assert.Equal(shops, result);
        }
        #endregion
    }
}
