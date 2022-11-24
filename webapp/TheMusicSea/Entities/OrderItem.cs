namespace TheMusicSea.Entities
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ItemSKU { get; set; }
        public int Quantity { get; set; }

        public OrderItem(int id, int orderId, int itemSku, int quantity)
        {
            this.ID = id;
            this.OrderID = orderId;
            this.ItemSKU = itemSku;
            this.Quantity = quantity;
        }
    }
}
