using OrderShipping.Domain;
using OrderShipping.Repository;

namespace OrderShipping.UseCase
{
    public class OrderApprovalUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderApprovalUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Run(OrderApprovalRequest request)
        {
            var order = _orderRepository.GetById(request.OrderId);
            (Order? Success, ApplicationException? Error) result;

            if (request.Approved)
            {
                result = order.Approve();
            }
            else
            {
                result = order.Reject();
            }

            if (result.Error is not null)
            {
                throw result.Error;
            }

            _orderRepository.Save(order);
        }
    }
}
