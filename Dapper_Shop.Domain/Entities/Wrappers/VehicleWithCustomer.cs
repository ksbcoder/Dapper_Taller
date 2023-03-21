namespace Dapper_Shop.Domain.Entities.Wrappers
{
    public class VehicleWithCustomer
    {
        public int Vehicle_id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Km { get; set; }

        public CustomerWithShop Customer { get; set; }
    }
}
