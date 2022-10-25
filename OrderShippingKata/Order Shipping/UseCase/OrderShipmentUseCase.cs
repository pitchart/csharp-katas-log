using OrderShipping.Repository;
using OrderShipping.Service;

namespace OrderShipping.UseCase
{
    public class OrderShipmentUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShipmentService _shipmentService;

        public OrderShipmentUseCase(
            IOrderRepository orderRepository,
            IShipmentService shipmentService)
        {
            _orderRepository = orderRepository;
            _shipmentService = shipmentService;
        }

        public void Run(OrderShipmentRequest request)
        {
            var order = _orderRepository.GetById(request.OrderId);

            var result = order.Ship();

            if (result.Error is not null)
            {
                throw result.Error;
            }

            _shipmentService.Ship(order);

            _orderRepository.Save(order);
        }
    }
}
