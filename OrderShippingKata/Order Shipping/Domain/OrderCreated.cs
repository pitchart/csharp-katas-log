using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderCreated : OrderStatus
    {
        public void Approve(Order order)
        {
            order.Status = new OrderApproved();
        }

        public void Reject(Order order)
        {
            order.Status = new OrderRejected();
        }

        public void Ship(Order order)
        {
            throw new OrderCannotBeShippedException();
        }
    }

}
