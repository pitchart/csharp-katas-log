using OrderShipping.Domain;

namespace Order_Shipping.Domain
{
    public class OrderCreated : OrderState
    {
        public override OrderStatus State => OrderStatus.Created;

        public override OrderState Approve()
        {
            return new OrderApproved();
        }

        public override OrderState Reject()
        {
            return new OrderRejected();
        }
    }
}
