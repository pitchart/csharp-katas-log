using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderCreated : OrderStatus
    {
        public override void Approve(Order order)
        {
            order.StatusEnum = OrderStatusEnum.Approved;
        }

        public override void Reject(Order order)
        {
            order.StatusEnum = OrderStatusEnum.Rejected;
        }

        public override void Ship(Order order)
        {
            throw new OrderCannotBeShippedException();
        }

        public override OrderStatusEnum GetOrderStatusEnum()
        {
            return OrderStatusEnum.Created;
        }
    }

}
