using Order_Shipping.Domain;
using OrderShipping.Domain;
using OrderShipping.Repository;
using OrderShipping.UseCase;
using OrderShippingTest.Doubles;
using System;
using System.Collections.Generic;
using Xunit;

namespace OrderShippingTest.UseCase;

public class OrderCreationUseCaseTest
{
    private readonly TestOrderRepository _orderRepository;
    private readonly IProductCatalog _productCatalog;
    private readonly OrderCreationUseCase _useCase;

    public OrderCreationUseCaseTest()
    {
        var food = new Category
        {
            Name = "food",
            TaxPercentage = 10m
        };

        _productCatalog = new InMemoryProductCatalog(new List<Product>
            {
                new("salad", 3.56m, food),
                new("tomato", 4.65m, food)
            });

        _orderRepository = new TestOrderRepository();

        _useCase = new OrderCreationUseCase(_orderRepository, _productCatalog);
    }


    [Fact]
    public void SellMultipleItems()
    {
        var saladRequest = new SellItemRequest
        {
            ProductName = "salad",
            Quantity = 2
        };

        var tomatoRequest = new SellItemRequest
        {
            ProductName = "tomato",
            Quantity = 3
        };

        var request = new SellItemsRequest
        {
            Requests = new List<SellItemRequest> { saladRequest, tomatoRequest }
        };

        _useCase.Run(request);

        Order insertedOrder = _orderRepository.GetSavedOrder();
        Assert.IsType<OrderCreated>(insertedOrder.Status);
        Assert.Equal(23.19m, insertedOrder.Total);
        Assert.Equal(2.12m, insertedOrder.Tax);
        Assert.Equal("EUR", insertedOrder.Currency);
        Assert.Equal(2, insertedOrder.Items.Count);
        Assert.Equal("salad", insertedOrder.Items[0].Product.Name);
        Assert.Equal(3.56m, insertedOrder.Items[0].Product.Price.RoundedValue);
        Assert.Equal(2, insertedOrder.Items[0].Quantity);
        Assert.Equal(7.84m, insertedOrder.Items[0].TaxedAmount.RoundedValue);
        Assert.Equal(0.72m, insertedOrder.Items[0].Tax.RoundedValue);
        Assert.Equal("tomato", insertedOrder.Items[1].Product.Name);
        Assert.Equal(4.65m, insertedOrder.Items[1].Product.Price.RoundedValue);
        Assert.Equal(3, insertedOrder.Items[1].Quantity);
        Assert.Equal(15.35m, insertedOrder.Items[1].TaxedAmount.RoundedValue);
        Assert.Equal(1.40m, insertedOrder.Items[1].Tax.RoundedValue);
    }

    [Fact]
    public void UnknownProduct()
    {
        var request = new SellItemsRequest
        {
            Requests = new List<SellItemRequest> {
                    new SellItemRequest { ProductName = "unknown product"}
                }
        };

        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<UnknownProductException>(actionToTest);
    }
}
