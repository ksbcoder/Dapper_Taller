using Moq;
using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;
using Dapper_Shop.Domain.Entities.Wrappers;
using Castle.Core.Resource;
using Dapper_Shop.Infrastructure.Gateway;
using System.Data;
using Dapper_Shop.Infrastructure.SqlAdapter;
using Dapper;

namespace Tests
{
    public class VehicleRepositoryTest
    {
        private readonly Mock<IVehicleRepository> _mockVehicleRepository;
        public VehicleRepositoryTest()
        {
            _mockVehicleRepository = new();
        }
        #region tests
        [Fact]
        public async Task CreateVehicle()
        {
            //arrange
            var vehicleToCreate = new Vehicle
            {
                Brand = "Pagani Zonda",
                Model = 2009,
                Km = 600,
                Id_Customer = 1
            };
            var vehicleCreated = new Vehicle
            {
                Brand = "Pagani Zonda",
                Model = 2009,
                Km = 600,
                Id_Customer = 1
            };
            _mockVehicleRepository.Setup(x => x.CreateVehicle(vehicleToCreate)).ReturnsAsync(vehicleCreated);
            //act
            var result = await _mockVehicleRepository.Object.CreateVehicle(vehicleToCreate);
            //assert
            Assert.Equal(vehicleCreated, result);
        }
        [Fact]
        public async Task GetVehicles()
        {
            //arrange
            List<Vehicle> vehicles = new();
            var vehicle1 = new Vehicle
            {
                Brand = "Pagani Zonda",
                Model = 2009,
                Km = 600,
                Id_Customer = 1
            };
            var vehicle2 = new Vehicle
            {
                Brand = "Ferrari Berlinetta",
                Model = 2015,
                Km = 1000,
                Id_Customer = 1
            };
            vehicles.Add(vehicle1);
            vehicles.Add(vehicle2);
            _mockVehicleRepository.Setup(x => x.GetVehicles()).ReturnsAsync(vehicles);
            //act
            var result = await _mockVehicleRepository.Object.GetVehicles();
            //assert
            Assert.Equal(vehicles, result);
        }

        [Fact]
        public async Task GetVehicleWithCustomerAndShop()
        {
            //arrange
            VehicleWithCustomer vehicleExpects = new()
            {
                Brand = "Ferrari Berlinetta",
                Model = "2015",
                Km = 1000,
                Customer = new CustomerWithShop
                {
                    Fullname = "Santiago Baquero",
                    Phone_customer = "3008887755",
                    Address_customer = "Tv 4",
                    Shop = new Shop
                    {
                        Name_shop = "Victorys",
                        Address_shop = "Calle 1",
                        Phone_shop = "5558899",
                        Rating_shop = 1
                    }
                }
            };

            //_mockVehicleRepository.Setup(x => x.GetVehicleWithCustomerAndShop(1)).ReturnsAsync(vehicleExpects);
            ////act
            //var result = await _mockVehicleRepository.Object.GetVehicleWithCustomerAndShop(1);
            ////assert
            //Assert.Equal(vehicleExpects, result);
        }
        #endregion
    }
}
