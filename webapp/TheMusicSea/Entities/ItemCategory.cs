using System.Data;

namespace TheMusicSea.Entities
{
    public class ItemCategory
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int CategoryID { get; set; }

        public ItemCategory(int id, int itemId, int categoryId)
        {
            ID = id;
            ItemID = itemId;
            CategoryID = categoryId;
        }

        public static ItemCategory FromDataRow(DataRow row)
        {
            return new ItemCategory(
                Convert.ToInt32(row["ID"]),
                Convert.ToInt32(row["ItemID"]),
                Convert.ToInt32(row["CategoryID"]));
        }
    }
}
