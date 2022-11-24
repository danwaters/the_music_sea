using System.Data;

namespace TheMusicSea.Entities
{
	public class Item
	{
		public int ID { get; private set; }
		public string SKU { get; set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public double MSRP { get; set; }
		public double Price { get; set; }
		public string PhotoURI { get; set; }
		public int InventoryCount { get; set; }
		public int DepartmentID { get; private set; }
		public List<int> CategoryIDs { get; set; }

		public Item(int id, string sku, string name, string description, double msrp, double price, string photoUri, int inventoryCount, int departmentId)
		{
			this.ID = id;
			this.SKU = sku;
			this.Name = name;
			this.Description = description;
			this.MSRP = msrp;
			this.Price = price;
			this.PhotoURI = photoUri;
			this.InventoryCount = inventoryCount;
			this.DepartmentID = departmentId;
		}

		public static Item FromDataRow(DataRow row)
		{
            return new Item(
                Convert.ToInt32(row["ID"]),
                row["SKU"].ToString(),
                row["Name"].ToString(),
                row["Description"].ToString(),
                Convert.ToDouble(row["MSRP"]),
                Convert.ToDouble(row["Price"]),
                row["PhotoURI"].ToString(),
                Convert.ToInt32(row["InventoryCount"]),
                Convert.ToInt32(row["DepartmentID"]));
        }
	}
}
