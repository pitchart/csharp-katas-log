using Order_Shipping.Domain;

namespace OrderShipping.Domain
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Amount TaxedAmount => Product.UnitaryTaxedAmount * Quantity;
        public Amount Tax => Product.UnitaryTax * Quantity;
    }
}
