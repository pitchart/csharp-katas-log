using System;
using OrderShipping.Domain.ValueObjects;
using Xunit;

namespace OrderShippingTest.ValueObjects
{
    public class PriceTests
    {
        [Fact]
        public void price_should_be_rounded_with_2_decimals_when_having_more_and_last_decimal_is_more_than_5()
        {
            Price price = new Price(45.236m, "EUR");

            Assert.Equal(45.24m, price.Round());
        }

        [Fact]
        public void price_should_be_rounded_with_2_decimals_when_having_more_and_last_decimal_is_less_than_5()
        {
            Price price = new Price(45.231m, "EUR");

            Assert.Equal(45.24m, price.Round());
        }

        [Fact]
        public void price_should_be_multiplied_be_a_common_factor_when_requested()
        {
            Price price = new Price(45.231m, "EUR") * 2;

            Assert.Equal(90.462m, price.UnitaryPrice);
        }

        [Fact]
        public void should_have_tax_applied_when_supplying_tax_percentage()
        {
            Price price = new Price(45.231m, "EUR");
            Price tax = price.ApplyTax(10);

            Assert.Equal(4.5231m, tax.UnitaryPrice);
        }

        [Fact]
        public void should_add_two_prices()
        {
            Price price1 = new Price(45.231m, "EUR");
            Price price2 = new Price(31.481m, "EUR");

            Assert.Equal(76.712m, (price1 + price2).UnitaryPrice);
        }

        [Fact]
        public void should_not_add_two_prices_with_differents_currency()
        {
            Price price1 = new Price(45.231m, "USD");
            Price price2 = new Price(31.481m, "EUR");

            var exception = Assert.Throws<InvalidOperationException>(() => (price1 + price2));
            Assert.Equal("Prices with different currencies cannot be added", exception.Message);
        }
    }
}
