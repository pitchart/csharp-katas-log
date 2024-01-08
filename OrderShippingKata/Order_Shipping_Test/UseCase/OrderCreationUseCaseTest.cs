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
                new Product
                {
                    Name = "salad",
                    Price = new Price(3.56m, "EUR"),
                    Category = food
                },
                new Product
                {
                    Name = "tomato",
                    Price = new Price(4.65m, "EUR"),
                    Category = food
                }
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
        Assert.Equal(OrderStatus.Created, insertedOrder.State.Status);
        Assert.Equal(new Price(23.20m, "EUR"), insertedOrder.Total);
        Assert.Equal(new Price(2.13m, "EUR"), insertedOrder.Tax);
        Assert.Equal("EUR", insertedOrder.Currency);
        Assert.Equal(2, insertedOrder.Items.Count);
        Assert.Equal("salad", insertedOrder.Items[0].Product.Name);
        Assert.Equal(new Price(3.56m, "EUR"), insertedOrder.Items[0].Product.Price);
        Assert.Equal(2, insertedOrder.Items[0].Quantity);
        Assert.Equal(new Price(7.84m, "EUR"), insertedOrder.Items[0].TaxedAmount);
        Assert.Equal(new Price(0.72m, "EUR"), insertedOrder.Items[0].Tax);
        Assert.Equal("tomato", insertedOrder.Items[1].Product.Name);
        Assert.Equal(new Price(4.65m, "EUR"), insertedOrder.Items[1].Product.Price);
        Assert.Equal(3, insertedOrder.Items[1].Quantity);
        Assert.Equal(new Price(15.36m, "EUR"), insertedOrder.Items[1].TaxedAmount);
        Assert.Equal(new Price(1.41m, "EUR"), insertedOrder.Items[1].Tax);
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

    [Fact]
    public void NoProducts()
    {
        var request = new SellItemsRequest
        {
            Requests = new List<SellItemRequest>()
        };

        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<InvalidOrderException>(actionToTest);
    }

}
