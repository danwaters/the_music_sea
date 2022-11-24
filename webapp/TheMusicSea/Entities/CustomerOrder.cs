namespace TheMusicSea.Entities
{
    public class CustomerOrder
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime PlacedDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public double Subtotal { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public string TrackingCode { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public CustomerOrder(int id, int customerId, DateTime placedDate, DateTime shippedDate,
            OrderStatus status, double subtotal, double tax, double total, string trackingCode)
        {
            this.ID = id;
            this.CustomerID = customerId;
            this.PlacedDate = placedDate;
            this.ShippedDate = shippedDate;
            this.OrderStatus = status;
            this.Subtotal = subtotal;
            this.Tax = tax;
            this.Total = total;
            this.TrackingCode = trackingCode;
            OrderItems = new List<OrderItem>();
        }
    }
}
