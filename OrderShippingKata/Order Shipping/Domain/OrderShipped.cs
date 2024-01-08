using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderShipped : OrderState
    {
        public override OrderStatus Status => OrderStatus.Shipped;

        public override OrderState Approve()
        {
            throw new ShippedOrdersCannotBeChangedException();
        }

        public override OrderState Reject()
        {
            throw new ShippedOrdersCannotBeChangedException();
        }

        public override OrderState Ship()
        {
            throw new OrderCannotBeShippedTwiceException();
        }
    }
}
