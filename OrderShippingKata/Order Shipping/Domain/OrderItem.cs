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
                 return Product.TaxedAmount * Quantity;
            }
        }
        public decimal Tax
        {
            get
            {
                return Product.Tax * Quantity;
            }
        }

        internal static OrderItem CreateOrderItem(Product product, int quantity)
        {
            return new OrderItem
            {
                Product = product,
                Quantity = quantity
            };
        }
    }
}
