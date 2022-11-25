using System.Data;

namespace TheMusicSea.Entities
{
    public class CartItem
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }

        public Item? Item { get; set; }

        public double LineItemPrice
        {
            get
            {
                return Quantity * Item.Price;
            }
        }

        public CartItem(int id, int cartId, int itemId, int quantity)
        {
            this.ID = id;
            this.CartID = cartId;
            this.ItemID = itemId;
            this.Quantity = quantity;
        }

        public static CartItem FromDataRow(DataRow row)
        {
            return new CartItem(
                Convert.ToInt32(row["ID"]),
                Convert.ToInt32(row["CartID"]),
                Convert.ToInt32(row["ItemID"]),
                Convert.ToInt32(row["Quantity"]));
        }
    }
}
