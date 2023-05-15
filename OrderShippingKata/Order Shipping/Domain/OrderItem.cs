namespace OrderShipping.Domain
{
    public class OrderItem
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;

            var unitaryTax = Round((product.Price / 100m) * product.Category.TaxPercentage);
            var unitaryTaxedAmount = Round(product.Price + unitaryTax);
            TaxedAmount = Round(unitaryTaxedAmount * quantity);
            Tax = Round(unitaryTax * quantity);


        }

        public readonly Product Product;

        public readonly int Quantity;

        public readonly decimal TaxedAmount;

        public readonly decimal Tax;

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}
    
