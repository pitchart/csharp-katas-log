using OrderShipping.Domain;
using Xunit;

namespace OrderShippingTest.Domain
{
    public class OrderTests
    {
        [Fact]
        public void Should_CreatedStatusAndEurosCurrency_WhenInitialiseOrder()
        {
            var order = new Order();

            Assert.Equal(OrderStatus.Created, order.Status);
            Assert.Equal("EUR", order.Currency);
            Assert.Empty(order.Items);
            Assert.Equal(0, order.Tax);
            Assert.Equal(0, order.Total);
        }
    }
}
