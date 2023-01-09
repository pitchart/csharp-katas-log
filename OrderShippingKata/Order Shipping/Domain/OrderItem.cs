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
            TaxedAmount = (product.UnitaryTaxedAmount.Round()* quantity).Round();
            // trop d'arrondis
            Tax = ((product.Price / 100m * product.Category.TaxPercentage).Round() * quantity).Round();
        }
    }
}
