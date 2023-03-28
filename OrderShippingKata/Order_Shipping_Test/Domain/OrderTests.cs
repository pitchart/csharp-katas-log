using Order_Shipping.Domain;
using OrderShipping.Domain;
using OrderShipping.UseCase;
using Xunit;
using Xunit.Sdk;
using static OrderShippingTest.Doubles.Builder.OrderBuilder;

namespace OrderShippingTest.Domain
{

    public class OrderTests
    {
        [Fact]
        public void Should_CreatedStatusAndEurosCurrency_WhenInitialiseOrder()
        {
            var order = new Order();

            Assert.IsType<OrderCreated>(order.Status);
            Assert.Equal("EUR", order.Currency);
            Assert.Empty(order.Items);
            Assert.Equal(0, order.Tax);
            Assert.Equal(0, order.Total);
        }

        [Fact]
        public void Should_SumTaxAndCalculateTotal_WhenAddOrderItems()
        {
            var order = new Order();

            order.AddProduct(new Product("A product", 10, new Category { TaxPercentage = 10 }), 1);
            order.AddProduct(new Product("A product", 50, new Category { TaxPercentage = 50 }), 1);

            Assert.Equal(2, order.Items.Count);
            Assert.Equal(26, order.Tax);
            Assert.Equal(86, order.Total);
        }

        [Fact]
        public void ShouldApproveNewOrder()
        {
            var newOrder = ANewOrder().Build();
            newOrder.Approve();

            Assert.IsType<OrderApproved>(newOrder.Status);
        }

        [Fact]
        public void CannotApproveRejectedOrder()
        {
            var rejectedOrder = ARejectedOrder().Build();
            var result = rejectedOrder.Approve();

            result.Match(
                Left: ex => Assert.IsType<RejectedOrderCannotBeApprovedException>(ex),
                Right: _ => throw new XunitException("Should never return order")
                );
        }

        [Fact]
        public void ShouldShipAnApprovedOrder()
        {
            var newOrder = ANewOrder().Build();
            newOrder.Approve();

            var result = newOrder.Ship();

            result.Match(
                Left: _ => throw new XunitException("Should never return order"),
                Right: order => Assert.IsType<OrderShipped>(order.Status)
            );
        }
    }

}
