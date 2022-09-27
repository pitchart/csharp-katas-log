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

        [Fact]
        public void Should_SumTaxAndCalculateTotal_WhenAddOrderItems()
        {
            var order = new Order();

            var orderItemPrice10Tax1 = new OrderItem
            {
                Product = new Product("A product", 10, new Category { TaxPercentage = 10 }),
                Quantity = 1
            };

            var orderItemPrice50Tax25 = new OrderItem
            {
                Product = new Product("A product", 50, new Category { TaxPercentage = 50 }),
                Quantity = 1
            };

            order.AddOrderItem(orderItemPrice10Tax1);
            order.AddOrderItem(orderItemPrice50Tax25);

            Assert.Equal(2, order.Items.Count);
            Assert.Equal(26, order.Tax);
            Assert.Equal(86, order.Total);
        }
    }
}
