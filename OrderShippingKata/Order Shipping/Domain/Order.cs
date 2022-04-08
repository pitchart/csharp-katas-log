using OrderShipping.Service;
using OrderShipping.UseCase;

namespace OrderShipping.Domain
{
    public class Order
    {
        private const string CURRENCY_EUR = "EUR";

        public decimal Total { get; set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Tax { get; set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }



        private void StatusCanBeChanged(OrderApprovalRequest request)
        {
            if (this.Status == OrderStatus.Shipped)
            {
                throw new ShippedOrdersCannotBeChangedException();
            }

            if (request.Approved && this.Status == OrderStatus.Rejected)
            {
                throw new RejectedOrderCannotBeApprovedException();
            }

            if (!request.Approved && this.Status == OrderStatus.Approved)
            {
                throw new ApprovedOrderCannotBeRejectedException();
            }
        }

        private void CanBeShipped()
        {
            if (this.Status == OrderStatus.Created || this.Status == OrderStatus.Rejected)
            {
                throw new OrderCannotBeShippedException();
            }

            if (this.Status == OrderStatus.Shipped)
            {
                throw new OrderCannotBeShippedTwiceException();
            }
        }

        public void Ship(IShipmentService service)
        {
            this.CanBeShipped();
            service.Ship(this);
            this.Status = OrderStatus.Shipped;
        }

        internal static Order CreateOrder()
        {
            return new Order
            {
                Status = OrderStatus.Created,
                Items = new List<OrderItem>(),
                Currency = CURRENCY_EUR,
                Total = 0m,
                Tax = 0m
            };
        }

        public void ChangeStatus(OrderApprovalRequest request)
        {
            StatusCanBeChanged(request);

            this.Status = request.Approved ? OrderStatus.Approved : OrderStatus.Rejected;
        }

        internal void AddOrderItem(OrderItem orderItem)
        {
            this.Items.Add(orderItem);
            this.Total += orderItem.TaxedAmount;
            this.Tax += orderItem.Tax;
        }
    }
}
