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
            Amount amount = new(150.163m);

            Assert.Equal(150.17m, amount.RoundedValue);
        }

        [Fact]
        public void Should_be_divisible_by_decimal_value()
        {
            Amount amount = new(150.163m);

            var result = amount / 10m;
            Assert.Equal(15.02m, result.RoundedValue);
        }

        [Fact]
        public void Should_not_be_divisible_by_zero()
        {
            Assert.Throws<DivideByZeroException>(() => new Amount(150.163m)/0);
        }

        [Fact]
        public void Should_be_additionable()
        {
            Amount amount_30_25 = new(30.25m);
            Amount amount_25 = new(25m);


            var result = amount_30_25 + amount_25;
            Assert.Equal(55.25m, result.RoundedValue);
        }
    }

    public class Amount
    {
        private readonly decimal _amount;

        public Amount(decimal amount)
        {
            _amount = amount;
        }

        public decimal RoundedValue => decimal.Round(_amount, 2, MidpointRounding.ToPositiveInfinity);

        public static Amount operator /(Amount amount, decimal value) => new(amount._amount / value);

        public static Amount operator +(Amount amount, Amount other) => new(amount._amount + other._amount);
    }

}
