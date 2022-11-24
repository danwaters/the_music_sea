using System.Data;

namespace TheMusicSea.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Category(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public static Category FromDataRow(DataRow row)
        {
            return new Category(
                Convert.ToInt32(row["ID"]),
                row["Name"].ToString());
        }
    }
}
