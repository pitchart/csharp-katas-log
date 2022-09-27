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
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public decimal UnitaryTax => PriceHelper.Round((Price / 100m) * Category.TaxPercentage);
        public decimal UnitaryTaxedAmount => PriceHelper.Round(Price + UnitaryTax);
    }
}
