namespace Dapper_Shop.Domain.Entities
{
    public class Shop
    {
        public int Shop_id { get; set; }
        public string Name_shop { get; set; }
        public string Address_shop { get; set; }
        public string Phone_shop { get; set; }
        public int Rating_shop { get; set; }

        public Shop(int id, string name, string address, string phone, int rating)
        {
            Shop_id = id;
            Name_shop = name;
            Address_shop = address;
            Phone_shop = phone;
            Rating_shop = rating;
        }

        public Shop() { }

        public static void Validate(string name, string address, string phone, int rating)
        {
            if (name.Equals(null))
            {
                throw new ArgumentNullException("Name cannot be null");
            }
            if (address.Equals(null))
            {
                throw new ArgumentNullException("Address name cannot be null");
            }
            if (phone.Equals(null))
            {
                throw new ArgumentNullException("Phone cannot be null");
            }
            if (rating <= 0)
            {
                throw new ArgumentException("Rating cannot be less than zero");
            }
        }
    }
}
