using System.Data;

namespace TheMusicSea.Entities
{
    public class Department
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Department(int id, string name, string description)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
        }

        public static Department FromDataRow(DataRow row)
        {
            return new Department(
                Convert.ToInt32(row["ID"]),
                row["Name"].ToString(),
                row["Description"].ToString());
        }
    }
}
