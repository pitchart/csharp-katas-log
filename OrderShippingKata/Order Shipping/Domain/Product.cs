using OrderShipping.Domain.ValueObjects;

namespace OrderShipping.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public Price Price { get ; set; }
        public Category Category { get; set; }
    }
}
