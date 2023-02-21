using OrderShipping.Domain;

namespace Order_Shipping.Domain
{
    public class OrderApproved : OrderStatus
    {
        public override void Approve(Order order)
        {
            return;
        }
    }
}
