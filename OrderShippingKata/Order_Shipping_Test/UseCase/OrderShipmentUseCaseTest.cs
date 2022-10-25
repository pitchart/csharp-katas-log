using OrderShipping.Domain;
using OrderShipping.UseCase;
using OrderShippingTest.Doubles;
using System;
using Xunit;
using static OrderShippingTest.Doubles.Builder.OrderBuilder;

namespace OrderShippingTest.UseCase;

public class OrderShipmentUseCaseTest
{
    private readonly TestOrderRepository _orderRepository;
    private readonly TestShipmentService _shipmentService;
    private readonly OrderShipmentUseCase _useCase;

    public OrderShipmentUseCaseTest()
    {
        _orderRepository = new TestOrderRepository();
        _shipmentService = new TestShipmentService();
        _useCase = new OrderShipmentUseCase(_orderRepository, _shipmentService);
    }

    [Fact]
    public void ShipApprovedOrder()
    {
        var initialOrder = AnApprovedOrder().WithId(1).Build();

        _orderRepository.AddOrder(initialOrder);

        var request = new OrderShipmentRequest
        {
            OrderId = 1
        };

        _useCase.Run(request);

        Assert.Equal(OrderStatus.Shipped, _orderRepository.GetSavedOrder().Status);
        Assert.Same(initialOrder, _shipmentService.GetShippedOrder());
    }

    [Fact]
    public void CreatedOrdersCannotBeShipped()
    {
        var initialOrder = ANewOrder().WithId(1).Build();

        _orderRepository.AddOrder(initialOrder);

        var request = new OrderShipmentRequest
        {
            OrderId = 1
        };

        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<OrderCannotBeShippedException>(actionToTest);
        Assert.Null(_orderRepository.GetSavedOrder());
        Assert.Null(_shipmentService.GetShippedOrder());
    }

    [Fact]
    public void RejectedOrdersCannotBeShipped()
    {
        var initialOrder = ARejectedOrder().WithId(1).Build();

        _orderRepository.AddOrder(initialOrder);

        var request = new OrderShipmentRequest
        {
            OrderId = 1
        };

        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<OrderCannotBeShippedException>(actionToTest);
        Assert.Null(_orderRepository.GetSavedOrder());
        Assert.Null(_shipmentService.GetShippedOrder());
    }

    [Fact]
    public void ShippedOrdersCannotBeShippedAgain()
    {
        var initialOrder = AShippedOrder().WithId(1).Build();

        _orderRepository.AddOrder(initialOrder);

        var request = new OrderShipmentRequest
        {
            OrderId = 1
        };

        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<OrderCannotBeShippedTwiceException>(actionToTest);
        Assert.Null(_orderRepository.GetSavedOrder());
        Assert.Null(_shipmentService.GetShippedOrder());
    }

}
