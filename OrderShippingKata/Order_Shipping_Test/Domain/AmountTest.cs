using Order_Shipping.Domain;
using System;
using Xunit;

namespace OrderShippingTest.Domain
{
    public class AmountTest
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
            Assert.Throws<DivideByZeroException>(() => new Amount(150.163m) / 0);
        }

        [Fact]
        public void Should_be_additionable()
        {
            Amount amount_30_25 = new(30.25m);
            Amount amount_25 = new(25m);


            var result = amount_30_25 + amount_25;
            Assert.Equal(55.25m, result.RoundedValue);
        }

        [Fact]
        public void Should_be_multiplyable_by_decimal_value()
        {
            Amount amount_30_25 = new(30.25m);

            var result = amount_30_25 * 10.10m;
            Assert.Equal(305.53m, result.RoundedValue);
        }

        [Fact]
        public void Should_be_equal_to_its_decimal_rounded_value()
        {
            Amount amount_30_253 = new(30.253m);

            Assert.True(30.26m == amount_30_253);
            Assert.True(amount_30_253 == 30.26m);
        }

        [Fact]
        public void Should_be_equal_to_amount_of_same_rounded_value()
        {
            Amount amount_30_253 = new(30.253m);
            Amount amount_30_253_V2 = new(30.253m);

            Assert.Equal(amount_30_253_V2, amount_30_253);
        }
    }

}
