using System.Data;

namespace TheMusicSea.Entities
{
    public class Customer
    {
        // This field helps us view the app from the perspective of the test user.
        // In real life, this would be replaced with a login flow and cookie storage.
        // Customer 1 is prepopulated in the database.
        public static int DefaultCustomerID = 1;
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
        public int SalesEngineerID { get; set; }

        public Customer(int id, string firstName, string lastName, string email, string phone,
            string addressLine1, string addressLine2, string city, string stateProvince,
            string postcode, string country, int salesEngineerId)
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
            this.SalesEngineerID = salesEngineerId;
        }

        public static Customer FromDataRow(DataRow row)
        {
            return new Customer(
                Convert.ToInt32(row["ID"]),
                row["FirstName"].ToString(),
                row["LastName"].ToString(),
                row["Email"].ToString(),
                row["Phone"].ToString(),
                row["AddressLine1"].ToString(),
                row["AddressLine2"].ToString(),
                row["City"].ToString(),
                row["StateProvince"].ToString(),
                row["Postcode"].ToString(),
                row["Country"].ToString(),
                Convert.ToInt32(row["SalesEngineerID"]));
        }
    }
}
