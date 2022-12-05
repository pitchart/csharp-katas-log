namespace OrderShipping.Domain
{
    public class Product
    {
        public string Name { get; }
        public Amount Price { get; }
        public Category Category { get; }
        private Amount UnitaryTax => (Price / 100m) * Category.TaxPercentage;
        public Amount UnitaryTaxedAmount => Price + UnitaryTax;

        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}
