using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.Entities.Wrappers;
using Dapper_Shop.Domain.UseCases.Gateway;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;

namespace Dapper_Shop.Domain.UseCases.UseCases
{
    public class VehicleUseCase : IVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            return await _vehicleRepository.CreateVehicle(vehicle);
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _vehicleRepository.GetVehicles();
        }

        public async Task<IEnumerable<VehicleWithCustomer>> GetVehicleWithCustomerAndShop(int id)
        {
            return await _vehicleRepository.GetVehicleWithCustomerAndShop(id);
        }
    }
}
