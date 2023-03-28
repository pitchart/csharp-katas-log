using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderShipped : OrderStatus
    {
        public void Approve(Order order)
        {
            throw new ShippedOrdersCannotBeChangedException();
        }

        public void Reject(Order order)
        {
            throw new ShippedOrdersCannotBeChangedException();
        }

        public void Ship(Order order)
        {
            throw new OrderCannotBeShippedTwiceException();
        }
    }
}
