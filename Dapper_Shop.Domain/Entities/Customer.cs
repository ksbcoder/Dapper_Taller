namespace Dapper_Shop.Domain.Entities
{
    public class Customer
    {
        public int Customer_id { get; set; }
        public string Fullname { get; set; }
        public string Address_customer { get; set; }
        public string Phone_customer { get; set; }

        public int Id_shop { get; set; }
    }
}
