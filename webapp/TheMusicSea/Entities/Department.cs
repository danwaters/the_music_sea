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
    }
}
