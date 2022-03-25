namespace OrderShipping.Domain
{
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(Product product, int quantity)
        {
            var unitaryTax = Round((product.Price / 100m) * product.Category.TaxPercentage);
            var unitaryTaxedAmount = Round(product.Price + unitaryTax);
            var taxedAmount = Round(unitaryTaxedAmount * quantity);
            var taxAmount = Round(unitaryTax * quantity);

            Product = product;
            Quantity = quantity;
            Tax = taxAmount;
            TaxedAmount = taxedAmount;
        }

        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public decimal TaxedAmount { get; set; }
        public decimal Tax { get; set; }

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }


    }
}
