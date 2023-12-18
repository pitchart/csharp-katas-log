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

        //TODO state pattern
        public void Run(OrderApprovalRequest request)
        {
            var order = _orderRepository.GetById(request.OrderId);

            if (request.Approved)
            {
                order.Approve();
            }
            else
            {
                order.Reject();
            }

            _orderRepository.Save(order);
        }
    }
}
