using Dapper_Shop.Domain.Entities;

namespace Dapper_Shop.Domain.UseCases.Gateway
{
    public interface ICustomerUseCase
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> CreateCustomer(Customer customer);
    }
}
