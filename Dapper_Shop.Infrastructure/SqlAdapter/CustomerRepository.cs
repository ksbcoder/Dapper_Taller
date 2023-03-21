using Dapper;
using Dapper_Shop.Domain.Entities;
using Dapper_Shop.Domain.UseCases.Gateway.Repositories;
using Dapper_Shop.Infrastructure.Gateway;

namespace Dapper_Shop.Infrastructure.SqlAdapter
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string _tableName = "customers";

        public CustomerRepository(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            // verify that shop exist
            var shopSql = $"SELECT COUNT(*) FROM shop WHERE shop_id = @idShop;";
            var shopCount = await connection.ExecuteScalarAsync<int>(shopSql, new { idShop = customer.Id_shop});

            if (shopCount == 0)
            {
                throw new Exception("The shop doesn't exist");
            }

            var customerToCreate = new
            {
                fullname = customer.Fullname,
                phone = customer.Phone_customer,
                address = customer.Address_customer,
                idShop = customer.Id_shop,
            };

            Customer.Validate(customerToCreate.fullname, customerToCreate.address, customerToCreate.phone, customerToCreate.idShop);

            var sql = $"INSERT INTO {_tableName} (fullname, phone_customer, address_customer, id_shop) VALUES (@fullname, @phone, @address, @idShop);";

            var result = await connection.ExecuteAsync(sql, customerToCreate);
            connection.Close();
            return customer;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();

            var sql = $"SELECT * FROM {_tableName}";
            var customers = await connection.QueryAsync<Customer>(sql);
            connection.Close();
            return customers.ToList();
        }
    }
}
