using OrderShipping.Domain;

namespace Order_Shipping.Domain
{
    public abstract class OrderState
    {
        public abstract OrderStatus State { get; }

        public static OrderState Create(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Created => new OrderCreated(),
                OrderStatus.Rejected => new OrderRejected(),
                OrderStatus.Approved => new OrderApproved(),
                OrderStatus.Shipped => new OrderShipped(),
                _ => throw new NotImplementedException(),
            };
        }

        public abstract OrderState Approve();

        public abstract OrderState Reject();
    }
}
