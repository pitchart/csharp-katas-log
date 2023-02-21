using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderRejected : OrderShipped
    {
        public override void Approve(Order order)
        {
            throw new RejectedOrderCannotBeApprovedException();
        }
    }
}
