using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderCreated : OrderState
    {
        public override OrderStatus Status => OrderStatus.Created;

        public override OrderState Approve()
        {
            return new OrderApproved();
        }

        public override OrderState Reject()
        {
            return new OrderRejected();
        }

        public override OrderState Ship()
        {
            throw new OrderCannotBeShippedException();
        }
    }
}
