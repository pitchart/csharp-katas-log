namespace OrderShipping.Domain
{
    public class Order
    {
        public Order(string currency, List<OrderItem> orderItems)
        {
            Currency =currency;
            Status = OrderStatus.Created;
            Items = new List<OrderItem>();
            foreach (var orderItem in orderItems)
            {
                AddItem(orderItem);
            }
        }

        public Order()
        {
        }

        public decimal Total { get; private set; }

        public readonly string Currency;
        public IList<OrderItem> Items { get; }
        public decimal Tax { get; private set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        public void AddItem(OrderItem item)
        {
            this.Items.Add(item);
            this.Total += item.TaxedAmount;
            this.Tax += item.Tax;
        }
    }
}
