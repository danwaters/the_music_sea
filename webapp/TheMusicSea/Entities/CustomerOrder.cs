using System.Data;

namespace TheMusicSea.Entities
{
    public class CustomerOrder
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime PlacedDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int OrderStatusID { get; set; }
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public string TrackingCode { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public CustomerOrder(int id, int customerId, DateTime placedDate, DateTime? shippedDate,
            int orderStatusId, double subtotal, double tax, double total, string trackingCode)
        {
            this.ID = id;
            this.CustomerID = customerId;
            this.PlacedDate = placedDate;
            this.ShippedDate = shippedDate;
            this.OrderStatusID = orderStatusId;
            this.Subtotal = subtotal;
            this.Tax = tax;
            this.Total = total;
            this.TrackingCode = trackingCode;
            OrderItems = new List<OrderItem>();
        }

        public static CustomerOrder FromDataRow(DataRow row)
        {
            return new CustomerOrder(
                Convert.ToInt32(row["ID"]),
                Convert.ToInt32(row["CustomerID"]),
                Convert.ToDateTime(row["PlacedDate"]),
                row["ShippedDate"] == DBNull.Value ? null : Convert.ToDateTime(row["ShippedDate"]),
                Convert.ToInt32(row["OrderStatusID"]),
                Convert.ToDouble(row["Subtotal"]),
                Convert.ToDouble(row["Tax"]),
                Convert.ToDouble(row["Total"]),
                row["TrackingCode"].ToString());
        }
    }
}
