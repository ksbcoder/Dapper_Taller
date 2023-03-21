namespace Dapper_Shop.Domain.Commands
{
    public class NewCustomer
    {
        public string Fullname { get; set; }
        public string Address_customer { get; set; }
        public string Phone_customer { get; set; }
        public int Id_shop { get; set; }
    }
}
