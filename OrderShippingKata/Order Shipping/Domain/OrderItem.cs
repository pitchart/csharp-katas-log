using Order_Shipping.Domain;

namespace OrderShipping.Domain
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TaxedAmount => PriceHelper.Round(Product.UnitaryTaxedAmount * Quantity);
        public decimal Tax => PriceHelper.Round(Product.UnitaryTax * Quantity);
    }
}
