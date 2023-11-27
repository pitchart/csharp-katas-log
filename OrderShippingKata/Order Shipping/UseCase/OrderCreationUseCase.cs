using OrderShipping.Domain;
using OrderShipping.Repository;

namespace OrderShipping.UseCase;

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
        var items = new List<OrderItem>();

        foreach (var itemRequest in request.Requests)
        {
            var product = _productCatalog.GetByName(itemRequest.ProductName);

            if (product == null)
            {
                throw new UnknownProductException();
            }
            items.Add(new OrderItem(product, itemRequest.Quantity));
        }

        var order = new Order(items, "EUR");

        _orderRepository.Save(order);
    }
}
