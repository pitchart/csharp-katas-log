using OrderShipping.UseCase;

namespace OrderShipping.Domain
{
    public class Order
    {
        public Order()
        {
            Status = OrderStatus.Created;
            Items = new List<OrderItem>();
            Currency = "EUR";
            Total = 0m;
            Tax = 0m;
        }

        public decimal Total { get; set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Tax { get; set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        internal void AddOrderItem(Product product, int quantity)
        {
            _ = product ?? throw new UnknownProductException();

            var orderItem = new OrderItem(product, quantity);

            Items.Add(orderItem);
            Total += orderItem.TaxedAmount;
            Tax += orderItem.Tax;
        }

        public void Approve(bool isApproved)
        {
            if (Status == OrderStatus.Shipped)
            {
                throw new ShippedOrdersCannotBeChangedException();
            }

            if (isApproved && Status == OrderStatus.Rejected)
            {
                throw new RejectedOrderCannotBeApprovedException();
            }

            if (!isApproved && Status == OrderStatus.Approved)
            {
                throw new ApprovedOrderCannotBeRejectedException();
            }

            Status = isApproved ? OrderStatus.Approved : OrderStatus.Rejected;
        }
    }
}
