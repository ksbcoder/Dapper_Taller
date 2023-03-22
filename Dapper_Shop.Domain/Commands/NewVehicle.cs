namespace Dapper_Shop.Domain.Commands
{
    public class NewVehicle
    {
        public string Brand { get; set; }
        public int Model { get; set; }
        public int Km { get; set; }
        public int Id_Customer { get; set; }
    }
}
