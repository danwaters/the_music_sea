using System.Data;

namespace TheMusicSea.Entities
{
    public class OrderStatus
    {
        public int ID { get; set; }
        public string Status { get; set; }

        public OrderStatus(int id, string status)
        {
            this.ID = id;
            this.Status = status;
        }

        public static OrderStatus FromDataRow(DataRow row)
        {
            return new OrderStatus(
                Convert.ToInt32(row["ID"]),
                row["status"].ToString());
        }
    }

    public enum OrderStatusEnum
    {
        Initiated = 1,
        Confirmed = 2,
        Shipped = 3,
        Canceled = 4,
        Closed = 5
    }
}
