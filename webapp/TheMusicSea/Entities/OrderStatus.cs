namespace TheMusicSea.Entities
{
    public class OrderStatus
    {
        public int ID { get; set; }
        public string Status { get; set; }

        public OrderStatus(int id, string status)
        {
            this.ID = id;
            this.Status = status;
        }
    }
}
