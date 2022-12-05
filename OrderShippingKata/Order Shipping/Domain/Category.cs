namespace OrderShipping.Domain
{
    public class Category
    {
        public string Name { get; set; }
        public Amount TaxPercentage { get; init; }
    }
}
