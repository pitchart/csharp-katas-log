namespace OrderShipping.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }

        public decimal GetTax()
        {
            return Round((Price / 100m) * Category.TaxPercentage);
        }

        public decimal GetTaxedAmount()
        {
            return Round(Price + GetTax());
        }

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}