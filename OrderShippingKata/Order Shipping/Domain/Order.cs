namespace OrderShipping.Domain
{
    public class Order
    {
        public Amount Total { get; set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; set; }
        public Amount Tax { get; set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        internal void Add(Product product, int quantity)
        {
            var taxedAmount = Round(Round(product.UnitaryTaxedAmount)* quantity);
            var taxAmount = Round(Round((product.Price / 100m) * product.Category.TaxPercentage) * quantity);
            var orderItem = new OrderItem(product, quantity);

            this.Items.Add(orderItem);
            this.Total += taxedAmount;
            this.Tax += taxAmount;
        }

        private decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, MidpointRounding.ToPositiveInfinity);
        }
    }
}
