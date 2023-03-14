using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderRejected : OrderStatus
    {
        public override void Approve(Order order)
        {
            throw new RejectedOrderCannotBeApprovedException();
        }

        public override void Reject(Order order)  { }

        public override void Ship(Order order)
        {
            throw new OrderCannotBeShippedException();
        }

        public override OrderStatusEnum GetOrderStatusEnum()
        {
            return OrderStatusEnum.Rejected;
        }
    }
}
