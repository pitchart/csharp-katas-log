using OrderShipping.Domain;
using OrderShipping.UseCase;

namespace Order_Shipping.Domain
{
    public class OrderRejected : OrderState
    {
        public override OrderStatus State => OrderStatus.Rejected;

        public override OrderState Approve()
        {
            throw new RejectedOrderCannotBeApprovedException();
        }

        public override OrderState Reject()
        {
            throw new NotImplementedException();
        }
    }
}
