using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.UseCases.Gateway;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;

namespace Dapper_Shop.Domain.UseCases.UseCases
{
    public class CustomerUseCase : ICustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await _customerRepository.CreateCustomer(customer);
        }
        public async Task<List<Customer>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }
    }
}
