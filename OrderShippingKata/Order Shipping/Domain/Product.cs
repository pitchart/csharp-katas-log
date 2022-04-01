namespace OrderShipping.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }

        public decimal Tax
        {
            get
            {
                return Round((Price / 100m) * Category.TaxPercentage);
            }
        }

        public decimal TaxedAmount
        {
            get
            {
                return Round(Price + Tax);
            }
        }

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}