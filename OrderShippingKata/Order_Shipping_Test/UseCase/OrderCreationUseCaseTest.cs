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
                new Product("salad", 3.56m, food),
                new Product("tomato", 4.65m,food)
            }); ;

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
        Assert.Equal(OrderStatus.Created, insertedOrder.Status);
        Assert.Equal(new Amount(23.20m), insertedOrder.Total);
        Assert.Equal(new Amount(2.13m), insertedOrder.Tax);
        Assert.Equal("EUR", insertedOrder.Currency);
        Assert.Equal(2, insertedOrder.Items.Count);
        Assert.Equal("salad", insertedOrder.Items[0].Product.Name);
        Assert.Equal(new Amount(3.56m), insertedOrder.Items[0].Product.Price);
        Assert.Equal(2, insertedOrder.Items[0].Quantity);
        Assert.Equal(new Amount(7.84m), insertedOrder.Items[0].TaxedAmount);
        Assert.Equal(new Amount(0.72m), insertedOrder.Items[0].Tax);
        Assert.Equal("tomato", insertedOrder.Items[1].Product.Name);
        Assert.Equal(new Amount(4.65m), insertedOrder.Items[1].Product.Price);
        Assert.Equal(3, insertedOrder.Items[1].Quantity);
        Assert.Equal(new Amount(15.36m), insertedOrder.Items[1].TaxedAmount);
        Assert.Equal(new Amount(1.41m), insertedOrder.Items[1].Tax);
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
