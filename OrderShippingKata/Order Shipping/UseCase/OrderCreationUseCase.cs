using OrderShipping.Domain;
using OrderShipping.Repository;

namespace OrderShipping.UseCase
{
    public class OrderCreationUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductCatalog _productCatalog;

        public OrderCreationUseCase(
            IOrderRepository orderRepository,
            IProductCatalog productCatalog)
        {
            _orderRepository = orderRepository;
            _productCatalog = productCatalog;
        }

        public void Run(SellItemsRequest request)
        {

            var orderItems = new List<OrderItem>();

            foreach (var itemRequest in request.Requests)
            {
                var product = _productCatalog.GetByName(itemRequest.ProductName);

                if (product == null)
                {
                    throw new UnknownProductException();
                }

                orderItems.Add(new OrderItem(product, itemRequest.Quantity));
            }
            var order = new Order("EUR", orderItems);

            _orderRepository.Save(order);
        }
    }
}
