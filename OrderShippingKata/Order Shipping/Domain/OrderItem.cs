using OrderShipping.Domain.ValueObjects;

namespace OrderShipping.Domain
{
    public class OrderItem
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;

            var unitaryTax = product.Price.ApplyTax(product.Category.TaxPercentage).Round();
            var unitaryTaxedAmount =  (product.Price + unitaryTax).Round();
            TaxedAmount = (unitaryTaxedAmount * quantity).Round();
            Tax = (unitaryTax * quantity).Round();
        }

        public readonly Product Product;
        public readonly int Quantity;
        public readonly Price TaxedAmount;
        public readonly Price Tax;
    }
}
    
