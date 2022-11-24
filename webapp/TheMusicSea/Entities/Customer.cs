namespace TheMusicSea.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

        public Customer(int id, string firstName, string lastName, string email, string phone,
            string addressLine1, string addressLine2, string city, string stateProvince,
            string postcode, string country)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
            this.City = city;
            this.StateProvince = stateProvince;
            this.Postcode = postcode;
            this.Country = country;
        }
    }
}
