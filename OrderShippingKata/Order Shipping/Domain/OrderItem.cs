namespace OrderShipping.Domain
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TaxedAmount 
        {
            get 
            {
                 return Product.GetTaxedAmount() * Quantity;

            }
        }
        public decimal Tax
        {
            get
            {
                return Round(Product.GetTax() * Quantity);

            }
        }

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}
