using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;
using Moq;
using Tests.Infrastructure.Shop.Builders;

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
                Name_shop = "prueba",
                Address_shop = "prueba",
                Phone_shop = "prueba",
                Rating_shop = 1
            };

            var shopCreated = new Shop
            {
                Name_shop = "prueba",
                Address_shop = "prueba",
                Phone_shop = "prueba",
                Rating_shop = 1
            };

            _mockshopRepository.Setup(x => x.CreateShop(shopToCreate)).ReturnsAsync(shopCreated);

            //act
            var result = await _mockshopRepository.Object.CreateShop(shopToCreate);

            //assert
            Assert.Equal(shopCreated, result);
        }
        //[Fact]
        //public async Task GetShops()
        //{
        //    //arrange
        //    var shopRepository = new ShopRepository(_mockConnectionBuilder.Object);

        //    //act
        //    var result = await shopRepository.GetShops();

        //    //assert
        //    Assert.NotEmpty(result);
        //    Assert.IsType<List<Dapper_Shop.Domain.Entities.Shop>>(result);
        //}
        #endregion
    }
}
