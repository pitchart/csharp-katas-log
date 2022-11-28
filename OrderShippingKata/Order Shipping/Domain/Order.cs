namespace OrderShipping.Domain
{
    public class Order
    {
        public decimal Total { get; set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Tax { get; set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        internal void Add(Product product, int quantity)
        {
            var unitaryTax = Round((product.Price / 100m) * product.Category.TaxPercentage);
            unitaryTax = Round(product.UnitaryTax);

            var unitaryTaxedAmount = Round(product.Price + unitaryTax);
            var taxedAmount = Round(unitaryTaxedAmount * quantity);
            var taxAmount = Round(unitaryTax *quantity);

            var orderItem = new OrderItem
            {
                Product = product,
                Quantity =quantity,
                Tax = taxAmount,
                TaxedAmount = taxedAmount
            };
            this.Items.Add(orderItem);
            this.Total += taxedAmount;
            this.Tax += taxAmount;
        }

        private decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}
