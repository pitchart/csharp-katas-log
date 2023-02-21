using OrderShipping.Domain;

namespace Order_Shipping.Domain
{
    public class OrderCreated : OrderStatus
    {
        public override void Approve(Order order)
        {
            order.StatusEnum = OrderStatusEnum.Approved;
        }
    }

}
