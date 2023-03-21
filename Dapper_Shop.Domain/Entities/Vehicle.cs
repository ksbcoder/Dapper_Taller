namespace Dapper_Shop.Domain.Entities
{
    public class Vehicle
    {
        public int Vehicle_id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Km { get; set; }

        public int Id_Customer { get; set; }
    }
}
