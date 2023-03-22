namespace Dapper_Shop.Domain.Entities
{
    public class Customer
    {
        public int Customer_id { get; set; }
        public string Fullname { get; set; }
        public string Address_customer { get; set; }
        public string Phone_customer { get; set; }

        public int Id_shop { get; set; }

        public Customer() { }

        public static void Validate(string name, string address, string phone, int idShop)
        {
            if (name.Equals(null))
            {
                throw new ArgumentNullException("Fullname cannot be null");
            }
            if (address.Equals(null))
            {
                throw new ArgumentNullException("Address name cannot be null");
            }
            if (phone.Equals(null))
            {
                throw new ArgumentNullException("Phone cannot be null");
            }
            if (idShop.Equals(null) || idShop.Equals(0))
            {
                throw new ArgumentNullException("IdShop cannot be null or zero");
            }
        }
    }
}
