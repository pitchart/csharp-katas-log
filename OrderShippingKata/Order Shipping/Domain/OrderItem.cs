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
            set {}
            }
        public decimal Tax { get; set; }
    }
}