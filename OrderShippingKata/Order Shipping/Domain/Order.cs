namespace OrderShipping.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Currency { get; }
        public IList<OrderItem> Items { get; }
        public decimal Tax => this.Items.Sum(item => item.Tax.RoundedValue);
        public decimal Total => this.Items.Sum(item => item.TaxedAmount.RoundedValue);

        public Order()
        {
            this.Status = OrderStatus.Created;
            this.Items = new List<OrderItem>();
            this.Currency = "EUR";
        }

        public void AddProduct(Product product, int quantity)
        {
            this.Items.Add(new OrderItem { Product = product, Quantity = quantity });
        }
    }
}
