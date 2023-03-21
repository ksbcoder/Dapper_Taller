using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.Entities.Wrappers;

namespace Dapper_Shop.Domain.UseCases.Gateway.Repositories
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetVehicles();
        Task<IEnumerable<VehicleWithCustomer>> GetVehicleWithCustomerAndShop(int id);
        Task<Vehicle> CreateVehicle(Vehicle vehicle);
    }
}
