using Order_Shipping.Domain;

namespace OrderShipping.Domain;

public class OrderItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal TaxedAmount { get; set; }
    public decimal Tax { get; set; }

    public OrderItem(Product product, int quantity)
    {
        var price = new Price(product.Price, "EUR");
        var unitaryTax = price.GetTax(product.Category.TaxPercentage).Round();
        var unitaryTaxedAmount = (unitaryTax + price).Round();
        var taxedAmount = (unitaryTaxedAmount * quantity).Round();
        var taxAmount = (unitaryTax * quantity).Round();

        Product = product;
        Quantity = quantity;
        Tax = taxAmount.Amount;
        TaxedAmount = taxedAmount.Amount;
    }
}
