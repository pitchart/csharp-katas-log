namespace OrderShipping.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public decimal UnitaryTax => (Price / 100m) * Category.TaxPercentage;
        public decimal UnitaryTaxedAmount => Price + UnitaryTax;

        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
