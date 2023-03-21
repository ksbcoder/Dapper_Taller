using AutoMapper;
using Dapper_Shop.Domain.Commands;
using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.Entities.Wrappers;
using Dapper_Shop.Domain.UseCases.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleUseCase _vehicleUseCase;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleUseCase vehicleUseCase, IMapper mapper)
        {
            _vehicleUseCase = vehicleUseCase;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _vehicleUseCase.GetVehicles();
        }
        [HttpGet("WithCustomerAndShop/{id}")]
        public async Task<IEnumerable<VehicleWithCustomer>> GetVehicleWithCustomerAndShop(int id)
        {
            return await _vehicleUseCase.GetVehicleWithCustomerAndShop(id);
        }
        [HttpPost]
        public async Task<Vehicle> CreateVehicle([FromBody] NewVehicle newVehicle)
        {
            return await _vehicleUseCase.CreateVehicle(_mapper.Map<Vehicle>(newVehicle));
        }
    }
}
