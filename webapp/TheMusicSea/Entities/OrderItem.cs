using System.Data;

namespace TheMusicSea.Entities
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }

        public OrderItem(int id, int orderId, int itemId, int quantity)
        {
            this.ID = id;
            this.OrderID = orderId;
            this.ItemID = itemId;
            this.Quantity = quantity;
        }

        public static OrderItem FromDataRow(DataRow row)
        {
            return new OrderItem(
                Convert.ToInt32(row["ID"]),
                Convert.ToInt32(row["OrderID"]),
                Convert.ToInt32(row["ItemID"]),
                Convert.ToInt32(row["Quantity"]));
        }
    }
}
