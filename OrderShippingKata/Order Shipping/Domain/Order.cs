using OrderShipping.UseCase;

namespace OrderShipping.Domain
{
    public class Order
    {
        public Order(params (int quantity, Product product)[] items)
        {
            foreach(var (quantity, product) in items)
            {
                Add(product, quantity);
            }
        }

        public Amount Total { get; private set; } = 0m;
        public string Currency { get; private set; } = "EUR";
        public IList<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public Amount Tax { get; private set; } = 0m;
        public OrderStatus Status { get; private set; } = OrderStatus.Created;
        public int Id { get;  set; }

        internal void Add(Product product, int quantity)
        {
            var taxedAmount = (product.UnitaryTaxedAmount.Round()* quantity).Round();
            var taxAmount = ((product.Price / 100m * product.Category.TaxPercentage).Round() * quantity).Round();
            var orderItem = new OrderItem(product, quantity);

            this.Items.Add(orderItem);
            this.Total += taxedAmount;
            this.Tax += taxAmount;
        }

        public void Approve()
        {
           Status = OrderStatus.Approved;
        }

        public void Ship()
        {
            if (Status == OrderStatus.Created || Status == OrderStatus.Rejected)
            {
                throw new OrderCannotBeShippedException();
            }

            if (Status == OrderStatus.Shipped)
            {
                throw new OrderCannotBeShippedTwiceException();
            }

            Status = OrderStatus.Shipped;
        }

        public void Reject()
        {
            Status = OrderStatus.Rejected;
        }
    }
}
