using Order_Shipping.Domain;

namespace OrderShipping.Domain
{
    public class Product
    {
        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Category = category;
            Price = new Amount(price);
            UnitaryTax = (Price / 100m) * category.TaxPercentage;
            UnitaryTaxedAmount = Price + UnitaryTax;
        }

        public string Name { get; }
        public Category Category { get; }
        public Amount Price { get; }
        public Amount UnitaryTax { get; }
        public Amount UnitaryTaxedAmount { get; }
    }
}
