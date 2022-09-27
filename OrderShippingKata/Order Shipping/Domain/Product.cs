using Order_Shipping.Domain;

namespace OrderShipping.Domain
{
    public class Product
    {
        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
            UnitaryTax = PriceHelper.Round((Price / 100m) * category.TaxPercentage);
            UnitaryTaxedAmount = PriceHelper.Round(price + UnitaryTax);
        }

        public string Name { get; }
        public decimal Price { get; }
        public Category Category { get; }
        public decimal UnitaryTax { get; }
        public decimal UnitaryTaxedAmount { get; }
    }
}
