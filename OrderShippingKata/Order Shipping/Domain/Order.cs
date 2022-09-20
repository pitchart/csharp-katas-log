namespace OrderShipping.Domain
{
    public class Order
    {
        public decimal Total { get; private set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; }
        public decimal Tax { get; private set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        public Order()
        {
            this.Status = OrderStatus.Created;
            this.Items = new List<OrderItem>();
            this.Currency = "EUR";
            this.Total = 0m;
            this.Tax = 0m;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            this.Items.Add(orderItem);
            this.Total += orderItem.TaxedAmount;
            this.Tax += orderItem.Tax;
        }
    }
}
