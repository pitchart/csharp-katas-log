namespace OrderShipping.Domain
{
    public class OrderItem
    {
        public Product Product { get; }
        public int Quantity { get; }
        public Amount TaxedAmount { get; }
        public Amount Tax { get; }

        public OrderItem(Product product, int quantity)
        {
            Product=product;
            Quantity=quantity;
            TaxedAmount = Round(Round(product.UnitaryTaxedAmount)* quantity);
            // trop d'arrondis
            Tax = Round(Round((product.Price / 100m) * product.Category.TaxPercentage) * quantity);
        }

        public OrderItem()
        { }

        private decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}
