using OrderShipping.Domain.Exceptions;
using OrderShipping.Domain.Services;

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


        private void StatusCanBeChanged(bool approved)
        {
            if (this.Status == OrderStatus.Shipped)
            {
                throw new ShippedOrdersCannotBeChangedException();
            }

            if (approved && this.Status == OrderStatus.Rejected)
            {
                throw new RejectedOrderCannotBeApprovedException();
            }

            if (!approved && this.Status == OrderStatus.Approved)
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
            // Voir l'ADR "exception-pure-domain.md"
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

        public void ChangeStatus(bool approved)
        {
            StatusCanBeChanged(approved);

            this.Status = approved ? OrderStatus.Approved : OrderStatus.Rejected;
        }

        internal void AddOrderItem(OrderItem orderItem)
        {
            this.Items.Add(orderItem);
            this.Total += orderItem.TaxedAmount;
            this.Tax += orderItem.Tax;
        }
    }
}
