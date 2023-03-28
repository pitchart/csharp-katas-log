using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderRejected : OrderStatus
    {
        public void Approve(Order order)
        {
            throw new RejectedOrderCannotBeApprovedException();
        }

        public void Reject(Order order) { }

        public void Ship(Order order)
        {
            throw new OrderCannotBeShippedException();
        }
    }
}
