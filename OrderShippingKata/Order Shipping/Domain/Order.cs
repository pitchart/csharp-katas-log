namespace OrderShipping.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Currency { get; }
        public IList<OrderItem> Items { get; }
        public decimal Tax => this.Items.Sum(item => item.Tax);
        public decimal Total => this.Items.Sum(item => item.TaxedAmount);

        public Order()
        {
            this.Status = OrderStatus.Created;
            this.Items = new List<OrderItem>();
            this.Currency = "EUR";
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            this.Items.Add(orderItem);
        }
    }
}
