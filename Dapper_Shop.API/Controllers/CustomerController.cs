using AutoMapper;
using Dapper_Shop.Domain.Commands;
using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.UseCases.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerUseCase _customerUseCase;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerUseCase customerUseCase, IMapper mapper)
        {
            _customerUseCase = customerUseCase;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<Customer>> GetCustomers()
        {
            return await _customerUseCase.GetCustomers();
        }
        [HttpPost]
        public async Task<Customer> CreateCustomer([FromBody] NewCustomer newCustomer)
        {
            return await _customerUseCase.CreateCustomer(_mapper.Map<Customer>(newCustomer));
        }
    }
}
