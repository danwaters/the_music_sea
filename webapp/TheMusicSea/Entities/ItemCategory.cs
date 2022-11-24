namespace TheMusicSea.Entities
{
    public class ItemCategory
    {
        public int ID { get; set; }
        public int ItemSKU { get; set; }
        public int CategoryID { get; set; }

        public ItemCategory(int id, int itemSku, int categoryId)
        {
            id = ID;
            ItemSKU = itemSku;
            CategoryID = categoryId;
        }
    }
}
