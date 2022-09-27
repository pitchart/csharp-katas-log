using OrderShipping.Domain;
using Xunit;

namespace OrderShippingTest
{
    public class OrderItemTests
    {
        private readonly Category CategoryWithTaxPercentageOf10 = new()
        {
            Name = "food",
            TaxPercentage = 10m
        };

        [Fact]
        public void Tax_should_be_unitaryTax_times_quantity()
        {
            Product productWithUnitaryTaxOf10 = new("salad", 100m, CategoryWithTaxPercentageOf10);

            var orderItem = new OrderItem
            {
                Product = productWithUnitaryTaxOf10,
                Quantity = 2
            };

            Assert.Equal(20, orderItem.Tax);
        }

        [Fact]
        public void TaxedAmount_should_be_unitaryTaxedAmount_times_quantity()
        {


            Product productWithUnitaryTaxAmountOf110 = new("salad", 100m, CategoryWithTaxPercentageOf10);

            var orderItem = new OrderItem
            {
                Product = productWithUnitaryTaxAmountOf110,
                Quantity = 2
            };

            Assert.Equal(220, orderItem.TaxedAmount);
        }
    }
}
