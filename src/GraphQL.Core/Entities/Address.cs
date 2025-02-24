using GraphQL.Core.Enums;

namespace GraphQL.Core.Entities
{
    public class Address : BaseEntity
    {
        public Address()
        {
        }

        public Address(string firstName, string lastName, string street, string city, string state, string zipcode, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            Zipcode = zipcode;
            Country = country;

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public AddressGroup AddressGroup {  get; set; }
        public bool IsDefault {  get; set; }
    }
}