namespace Dapper_Shop.Domain.Entities
{
    public class Vehicle
    {
        public int Vehicle_id { get; set; }
        public string Brand { get; set; }
        public int Model { get; set; }
        public int Km { get; set; }

        public int Id_Customer { get; set; }

        public Vehicle() { }

        public static void Validate(string brand, int model, int km, int idCustomer)
        {
            if (brand.Equals(null))
            {
                throw new ArgumentNullException("Brand cannot be null");
            }
            if (model.Equals(null) || model.Equals(0))
            {
                throw new ArgumentNullException("Model name cannot be null or zero");
            }
            if (km <= 500)
            {
                throw new ArgumentException("Km cannot be less than 500, this vehicle doesn't need reparation");
            }
            if (idCustomer.Equals(null) || idCustomer.Equals(0))
            {
                throw new ArgumentNullException("IdCustomer cannot be null or zero");
            }
        }
    }
}
