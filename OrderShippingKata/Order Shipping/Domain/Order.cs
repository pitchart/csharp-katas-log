namespace OrderShipping.Domain
{
    public class Order
    {
        public Order(string currency, List<OrderItem> orderItems)
        {
            if (orderItems == null || orderItems.Count == 0)
            {
                throw new InvalidOperationException();
            }

            Currency =currency;
            Status = OrderStatus.Created;
            Items = new List<OrderItem>();
            orderItems.ForEach(AddItem);
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
            Items.Add(item);
            Total += item.TaxedAmount;
            Tax += item.Tax;
        }
    }
}
