using System.Data;

namespace TheMusicSea.Entities
{
    public class Cart
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }

        public Cart(int id, int customerId)
        {
            this.ID = id;
            this.CustomerID = customerId;
        }

        public static Cart FromDataRow(DataRow row)
        {
            return new Cart(
                Convert.ToInt32(row["ID"]),
                Convert.ToInt32(row["CustomerID"]));
        }
    }
}
