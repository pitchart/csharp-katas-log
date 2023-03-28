using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderApproved : OrderStatus
    {
        public void Approve(Order order) { }

        public void Reject(Order order)
        {
            throw new ApprovedOrderCannotBeRejectedException();
        }

        public void Ship(Order order)
        {
            order.Status = new OrderShipped();
        }
    }
}
