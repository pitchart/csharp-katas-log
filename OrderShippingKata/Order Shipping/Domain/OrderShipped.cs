using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderShipped : OrderStatus
    {
        public override void Approve(Order order)
        {
            throw new ShippedOrdersCannotBeChangedException();
        }

        public override void Reject(Order order)
        {
            throw new ShippedOrdersCannotBeChangedException();
        }

        public override OrderStatusEnum GetOrderStatusEnum()
        {
            return OrderStatusEnum.Shipped;
        }

        public override void Ship(Order order)
        {
           throw new OrderCannotBeShippedTwiceException();
        }
    }
}
