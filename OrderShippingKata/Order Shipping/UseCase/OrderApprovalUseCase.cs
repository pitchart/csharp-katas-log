using LanguageExt;
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
            Order order = _orderRepository.GetById(request.OrderId);
            Either<ApplicationException, Order> result = request.Approved ? order.Approve() : order.Reject();

            result.Match(
                Left: ex => throw ex,
                Right: or => _orderRepository.Save(or));
        }
    }
}
