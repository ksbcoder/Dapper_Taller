using Dapper_Shop.Domain.Entities;

namespace Dapper_Shop.Domain.UseCases.Gateway.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> CreateCustomer(Customer customer);
    }
}
