using OrderShipping.Domain;
using OrderShipping.UseCase;
using OrderShippingTest.Doubles;
using System;
using Xunit;
using static OrderShippingTest.Doubles.Builder.OrderBuilder;

namespace OrderShippingTest.UseCase;

public class OrderApprovalUseCaseTest
{
    private readonly TestOrderRepository _orderRepository;
    private readonly OrderApprovalUseCase _useCase;

    public OrderApprovalUseCaseTest()
    {
        _orderRepository = new TestOrderRepository();
        _useCase = new OrderApprovalUseCase(_orderRepository);
    }

    [Fact]
    public void ApprovedExistingOrder()
    {
        var initialOrder = ANewOrder().WithId(1).Build();
        _orderRepository.AddOrder(initialOrder);

        var request = new OrderApprovalRequest
        {
            OrderId = 1,
            Approved = true
        };

        _useCase.Run(request);

        var savedOrder = _orderRepository.GetSavedOrder();
        Assert.Equal(OrderStatus.Approved, savedOrder.Status);
    }

    [Fact]
    public void RejectedExistingOrder()
    {
        var initialOrder = ANewOrder().WithId(1).Build();
        _orderRepository.AddOrder(initialOrder);

        var request = new OrderApprovalRequest
        {
            OrderId = 1,
            Approved = false
        };

        _useCase.Run(request);

        var savedOrder = _orderRepository.GetSavedOrder();
        Assert.Equal(OrderStatus.Rejected, savedOrder.Status);
    }


    [Fact]
    public void CannotApproveRejectedOrder()
    {
        var initialOrder = ARejectedOrder().WithId(1).Build();
        _orderRepository.AddOrder(initialOrder);

        var request = new OrderApprovalRequest
        {
            OrderId = 1,
            Approved = true
        };


        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<RejectedOrderCannotBeApprovedException>(actionToTest);
        Assert.Null(_orderRepository.GetSavedOrder());
    }

    [Fact]
    public void CannotRejectApprovedOrder()
    {
        var initialOrder = AnApprovedOrder().WithId(1).Build();

        _orderRepository.AddOrder(initialOrder);

        var request = new OrderApprovalRequest
        {
            OrderId = 1,
            Approved = false
        };


        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<ApprovedOrderCannotBeRejectedException>(actionToTest);
        Assert.Null(_orderRepository.GetSavedOrder());
    }

    [Fact]
    public void ShippedOrdersCannotBeRejected()
    {
        var initialOrder = AShippedOrder().WithId(1).Build();

        _orderRepository.AddOrder(initialOrder);

        var request = new OrderApprovalRequest
        {
            OrderId = 1,
            Approved = false
        };


        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<ShippedOrdersCannotBeChangedException>(actionToTest);
        Assert.Null(_orderRepository.GetSavedOrder());
    }
}
