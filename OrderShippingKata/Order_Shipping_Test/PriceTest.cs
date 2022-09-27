using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderShippingTest
{
    public class PriceTest
    {
        [Fact]
        public void Should_round_the_amount_with_two_digits()
        {
            Price price = new(150.163m);

            Assert.Equal(150.17m, price.RoundedValue);
        }

        [Fact]
        public void Should_be_divisible_by_decimal_value()
        {
            Price price = new(150.163m);

            var result = price / 10m;
            Assert.Equal(15.02m, result.RoundedValue);
        }
    }

    public class Price
    {
        private readonly decimal _amount;

        public Price(decimal amount)
        {
            _amount = amount;
        }

        public decimal RoundedValue => decimal.Round(_amount, 2, MidpointRounding.ToPositiveInfinity);

        public static Price operator /(Price price, decimal value) => new(price._amount / value);
    }

}
