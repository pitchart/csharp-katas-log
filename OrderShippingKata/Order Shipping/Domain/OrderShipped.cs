using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderShipped : OrderApproved
    {
        public override void Approve(Order order)
        {
            throw new ShippedOrdersCannotBeChangedException();
        }
    }
}
