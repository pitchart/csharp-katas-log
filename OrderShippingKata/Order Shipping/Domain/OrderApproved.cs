using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderApproved : OrderState
    {
        public override OrderStatus Status => OrderStatus.Approved;

        public override OrderState Approve()
        {
            throw new NotImplementedException();
        }

        public override OrderState Reject()
        {
            throw new ApprovedOrderCannotBeRejectedException();
        }

        public override OrderState Ship()
        {
            return new OrderShipped();
        }
    }
}
