using SamStore.Core.Domain;

namespace SamStore.Cliente.Domain.Customers
{
    public class CustomerAddress : Entity
    {
        public string ZipCode { get; private set; }
        public string Line1 { get; private set; }
        public string Line2 { get; private set; }
        public int Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        protected CustomerAddress() { }
        public CustomerAddress(string zipCode, string line1, string line2, int number, string district, string city, string state, string country)
        {
            ZipCode = zipCode;
            Line1 = line1;
            Line2 = line2;
            Number = number;
            District = district;
            City = city;
            State = state;
            Country = country;
        }
    }
}
