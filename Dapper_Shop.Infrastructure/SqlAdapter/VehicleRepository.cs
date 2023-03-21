using Dapper;
using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.Entities.Wrappers;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;
using Dapper_Shop.Infrastructure.Gateway;

namespace Dapper_Shop.Infrastructure.SqlAdapter
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string _tableName = "vehicles";

        public VehicleRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            // verify that client exist
            var customerSql = $"SELECT COUNT(*) FROM customers WHERE customer_id = @idCustomer;";
            var customerCount = await connection.ExecuteScalarAsync<int>(customerSql, new { idCustomer = vehicle.Id_Customer });

            if (customerCount == 0)
            {
                throw new Exception("The client doesn't exist");
            }

            var vehicleToCreate = new
            {
                brand = vehicle.Brand,
                model = vehicle.Model,
                km = vehicle.Km,
                idCustomer = vehicle.Id_Customer
            };

            Vehicle.Validate(vehicleToCreate.brand, vehicleToCreate.model, vehicleToCreate.km, vehicleToCreate.idCustomer);

            var sql = $"INSERT INTO {_tableName} (brand, model, km, id_customer) VALUES (@brand, @model, @km, @idCustomer);";

            var result = await connection.ExecuteAsync(sql, vehicleToCreate);
            connection.Close();
            return vehicle;
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var sql = $"SELECT * FROM {_tableName}";
            var vehicles = await connection.QueryAsync<Vehicle>(sql);
            connection.Close();
            return vehicles.ToList();
        }

        public async Task<IEnumerable<VehicleWithCustomer>> GetVehicleWithCustomerAndShop(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var sql =   $"SELECT * FROM {_tableName} v " +
                        $"INNER JOIN customers c ON c.customer_id = v.id_customer " +
                        $"INNER JOIN shop s ON s.shop_id = c.id_shop " +
                        $"WHERE v.vehicle_id = @id";

            var vehicle = await connection.QueryAsync<VehicleWithCustomer, CustomerWithShop, Shop, VehicleWithCustomer>(sql, (v, c, s) =>
            {
                v.Customer = c;
                v.Customer.Shop = s;
                return v;
            },
            new { id },
            splitOn: "Id_customer, Id_shop");

            connection.Close();
            return vehicle;
        }
    }
}
