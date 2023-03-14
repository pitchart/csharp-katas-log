using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderApproved : OrderStatus
    {
        public override void Approve(Order order) { }

        public override void Reject(Order order)
        {
            throw new ApprovedOrderCannotBeRejectedException();
        }

        public override void Ship(Order order)
        {
            order.StatusEnum = OrderStatusEnum.Shipped;
        }

        public override OrderStatusEnum GetOrderStatusEnum()
        {
            return OrderStatusEnum.Approved;
        }
    }
}
