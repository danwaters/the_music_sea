namespace TheMusicSea.Entities
{
	public class Item
	{
		public int SKU { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public double MSRP { get; set; }
		public double Price { get; set; }
		public string PhotoURI { get; set; }
		public int DepartmentID { get; private set; }

		public Item(int sku, string name, string description, double msrp, double price, string photoUri, int departmentId)
		{
			this.SKU = sku;
			this.Name = name;
			this.Description = description;
			this.MSRP = msrp;
			this.Price = price;
			this.PhotoURI = photoUri;
			this.DepartmentID = departmentId;
		}
	}
}
