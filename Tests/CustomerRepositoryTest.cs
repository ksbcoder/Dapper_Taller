using Moq;
using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;

namespace Tests
{
    public class CustomerRepositoryTest
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        public CustomerRepositoryTest()
        {
            _mockCustomerRepository = new();
        }
        #region tests
        [Fact]
        public async Task CreateCustomer()
        {
            //arrange
            var customerToCreate = new Customer
            {
                Fullname = "Santiago Baquero",
                Phone_customer = "3008887755",
                Address_customer = "Tv 4",
                Id_shop = 1
            };
            var customerCreated = new Customer
            {
                Fullname = "Santiago Baquero",
                Phone_customer = "3008887755",
                Address_customer = "Tv 4",
                Id_shop = 1
            };
            _mockCustomerRepository.Setup(x => x.CreateCustomer(customerToCreate)).ReturnsAsync(customerCreated);
            //act
            var result = await _mockCustomerRepository.Object.CreateCustomer(customerToCreate);
            //assert
            Assert.Equal(customerCreated, result);
        }
        [Fact]
        public async Task GetCustomers()
        {
            //arrange
            List<Customer> customers = new();
            var customer1 = new Customer
            {
                Fullname = "Santiago Baquero",
                Phone_customer = "3008887755",
                Address_customer = "Tv 4",
                Id_shop = 1
            };
            var customer2 = new Customer
            {
                Fullname = "Adryan Ynfante",
                Phone_customer = "9994477",
                Address_customer = "Carrera 2",
                Id_shop = 1
            };
            customers.Add(customer1);
            customers.Add(customer2);

            _mockCustomerRepository.Setup(x => x.GetCustomers()).ReturnsAsync(customers);
            //act
            var result = await _mockCustomerRepository.Object.GetCustomers();
            //assert
            Assert.Equal(customers, result);
        }
        #endregion
    }
}
