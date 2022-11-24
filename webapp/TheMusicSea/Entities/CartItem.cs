namespace TheMusicSea.Entities
{
    public class CartItem
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public int ItemSKU { get; set; }
        public int Quantity { get; set; }
        
        public CartItem(int id, int cartId, int itemSku, int quantity)
        {
            this.ID = id;
            this.CartID = cartId;
            this.ItemSKU = itemSku;
            this.Quantity = quantity;
        }
    }
}
