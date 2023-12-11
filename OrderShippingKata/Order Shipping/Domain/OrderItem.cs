using Order_Shipping.Domain;

namespace OrderShipping.Domain;

public class OrderItem
{
    public Product Product { get; }
    public int Quantity { get; }
    public Price TaxedAmount { get; }
    public Price Tax { get; }

    public OrderItem(Product product, int quantity)
    {
        var unitaryTax = product.GetTax().Round();
        var unitaryTaxedAmount = product.GetTaxedAmount().Round();
        var taxedAmount = (unitaryTaxedAmount * quantity).Round();
        var taxAmount = (unitaryTax * quantity).Round();

        Product = product;
        Quantity = quantity;
        Tax = taxAmount;
        TaxedAmount = taxedAmount;
    }
}
