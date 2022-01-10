using FluentAssertions;
using System;
using Xunit;

namespace Banking.Tests.Unit
{
    public class AmountTests
    {
        [Fact]
        public void Should_have_a_value()
        {
            //Arrange
            int givenValue = 1;

            //Act
            Amount amount = new Amount(givenValue);

            //Assert
            amount.Value.Should().Be(1);
        }

        [Fact]
        public void Should_have_a_value_with_cents()
        {
            //Arrange
            double givenValue = 1.05;

            //Act
            Amount amount = new Amount(givenValue);

            //Assert
            amount.Value.Should().Be(1.05);
        }

        [Fact]
        public void Should_not_have_a_negative_value()
        {
            //Act
            Action action = () => new Amount(-1);

            //Assert
            action.Should().ThrowExactly<Exception>("Amount should not be negative.");
        }

        [Fact]
        public void Should_add_amounts()
        {
            //Arrange
            Amount amount1 = new Amount(10);
            Amount amount2 = new Amount(100);

            //Act
            Amount amount3 = amount1 + amount2;

            //Assert
            amount3.Value.Should().Be(110);
        }

        [Fact]
        public void Should_substract_amounts()
        {
            //Arrange
            Amount amount1 = new Amount(100);
            Amount amount2 = new Amount(10);

            //Act
            Amount amount3 = amount1 - amount2;

            //Assert
            amount3.Value.Should().Be(90);
        }

        [Fact]
        public void Should_not_substract_amounts_when_result_is_negative()
        {
            //Arrange
            Amount amount1 = new Amount(10);
            Amount amount2 = new Amount(100);

            //Act
            Action action = () => { _ = amount1 - amount2; };

            //Assert
            action.Should().ThrowExactly<Exception>("Amount should not be negative.");
        }
    }
}
