using Order_Shipping.Domain;

namespace OrderShipping.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public Price Price { get; set; }
        public Category Category { get; set; }

        public Price GetTax() => Price.GetTax(Category.TaxPercentage);

        public Price GetTaxedAmount() => GetTax() + Price;
    }
}
